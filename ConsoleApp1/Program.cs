using System;
using Thrift;
using Thrift.Transport.Client;
using Thrift.Protocol;
using Nebula.Graph;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            GraphClient graphClient = new GraphClient("127.0.0.1", 9669);
            graphClient.Authenticate("root", "nebula");
            Console.WriteLine(graphClient.sessionId);

            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE SPACE IF NOT EXISTS test(vid_type=FIXED_STRING(30));");
            sb.Append("USE test;");
            sb.Append("CREATE TAG IF NOT EXISTS person(name string, age int);");
            sb.Append("CREATE EDGE like (likeness double);");

            var a = await graphClient.Execute(sb.ToString());

            await Task.Delay(10000);

            a = await graphClient.Execute("INSERT VERTEX person(name, age) VALUES \"Bob\":(\"Bob\", 10), \"Lily\":(\"Lily\", 9);");
            await Task.Delay(5000);
            a = await graphClient.Execute("INSERT EDGE like(likeness) VALUES \"Bob\"->\"Lily\":(80.0);");
            await Task.Delay(5000);
            a = await graphClient.Execute("FETCH PROP ON person \"Bob\" YIELD vertex as node;");
            await Task.Delay(5000);
            a = await graphClient.Execute("FETCH PROP ON like \"Bob\"->\"Lily\" YIELD edge as e;");
            Thread.Sleep(5000);
            await Task.Delay(5000);
            a = await graphClient.Execute("DROP SPACE test;");
            Thread.Sleep(5000);
            await Task.Delay(5000);

            await graphClient.SignOff();
        }
    }

    public class GraphClient
    {
        private TSocketTransport socketTransport { get; set; }
        private TBinaryProtocol protocolProtocol { get; set; }
        public GraphService.Client Client { get; set; }
        public long sessionId { get; set; }

        public GraphClient(string ip, int port)
        {
            var tConfiguration = new TConfiguration();
            socketTransport = new TSocketTransport(ip, port, tConfiguration);

            socketTransport.OpenAsync(default);

            protocolProtocol = new TBinaryProtocol(socketTransport);

            Client = new GraphService.Client(protocolProtocol);
        }

        public void Authenticate(string user, string passwd)
        {
            var authResponse = Client.authenticate(System.Text.Encoding.Default.GetBytes(user), System.Text.Encoding.Default.GetBytes(passwd)).Result;
            if (authResponse.Error_code != 0)
            {
                throw new Exception("error auth!");
            }
            else
            {
                sessionId = authResponse.Session_id;
            }
        }

        public async Task<ExecutionResponse> Execute(string statement)
        {
            var executionResponse = await Client.execute(sessionId, System.Text.Encoding.Default.GetBytes(statement));
            if (executionResponse.Error_code != 0)
            {
                throw new Exception(statement + " execute failed.");
            }

            return executionResponse;
        }

        public async Task SignOff()
        {
            await Client.signout(sessionId);
        }
    }
}