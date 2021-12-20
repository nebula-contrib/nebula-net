using System;
using Thrift;
using Thrift.Transport.Client;
using Thrift.Protocol;
using Nebula.Graph;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GraphClient graphClient = new GraphClient("127.0.0.1", 9669);
            graphClient.Authenticate("root", "nebula");
            Console.WriteLine(graphClient.sessionId);

            var response = graphClient.Execute("use basketballplayer;");

            graphClient.SignOff();
            Console.WriteLine("Hello World!");
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
            //var transport2 = new TMemoryBufferTransport(tConfiguration);

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

        public void SignOff()
        {
            Client.signout(sessionId).Wait();
        }
    }
}