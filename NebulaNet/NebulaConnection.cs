using Nebula.Graph;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Transport.Client;

namespace NebulaNet
{
    public class NebulaConnection
    {
        private TTransport transport { get; set; }
        private TProtocol protocol { get; set; }
        private GraphService.Client client { get; set; }

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <returns></returns>
        public async Task OpenAsync(string ip, int port)
        {
            if (IPAddress.TryParse(ip, out IPAddress iPAddress))
                transport = new TSocketTransport(iPAddress, port,null,timeout:10);
            else
                transport = new TSocketTransport(ip, port, null);

            protocol = new TBinaryProtocol(transport);

            client = new GraphService.Client(protocol);
            
            await client.OpenTransportAsync();
        }

        public AuthResponse Authenticate(string user, string passwd)
        {
            var authResponse = client.authenticate(Encoding.ASCII.GetBytes(user), Encoding.ASCII.GetBytes(passwd)).Result;

            if (authResponse.Error_code != 0)
            {
                throw new Exception("error auth!");
            }

            return authResponse;
        }
        public async Task<ExecutionResponse> Execute(long sessionID, string statement)
        {
            var executionResponse = await client.execute(sessionID, Encoding.UTF8.GetBytes(statement));
            if (executionResponse.Error_code != 0)
            {
                throw new Exception(Encoding.UTF8.GetString(executionResponse.Error_msg) + statement + " execute failed.");
            }

            return executionResponse;
        }
        public async Task SignOff(long sessionId)
        {
            await client.signout(sessionId);
        }
    }
}
