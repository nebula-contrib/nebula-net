using Nebula.Graph;
using System;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport.Client;
using System.Net;

namespace NebulaNet
{
    public class GraphClient
    {
        private TSocketTransport socketTransport { get; set; }
        private TBinaryProtocol protocolProtocol { get; set; }
        public GraphService.Client Client { get; set; }
        public long sessionId { get; set; }

        public GraphClient(string ip, int port)
        {
            var tConfiguration = new TConfiguration();

            if (IPAddress.TryParse(ip, out IPAddress iPAddress))
                socketTransport = new TSocketTransport(iPAddress, port, tConfiguration);
            else
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
                throw new Exception(System.Text.Encoding.ASCII.GetString(executionResponse.Error_msg) + statement + " execute failed.");
            }

            return executionResponse;
        }

        public async Task SignOff()
        {
            await Client.signout(sessionId);
        }
    }
}