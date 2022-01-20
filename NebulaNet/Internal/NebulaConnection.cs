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
    public class NebulaConnection : IDisposable
    {
        private TTransport Transport { get; set; }
        private TProtocol Protocol { get; set; }
        private GraphService.Client Client { get; set; }

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <returns></returns>
        public async Task OpenAsync(string ip, int port)
        {
            if (IPAddress.TryParse(ip, out IPAddress iPAddress))
                Transport = new TSocketTransport(iPAddress, port,null,timeout:10);
            else
                Transport = new TSocketTransport(ip, port, null);

            Protocol = new TBinaryProtocol(Transport);

            Client = new GraphService.Client(Protocol);
            
            await Client.OpenTransportAsync();
        }
        /// <summary>
        /// 验证用户名和密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthResponse> AuthenticateAsync(string user, string passwd)
        {
            var authResponse =await Client.authenticate(Encoding.ASCII.GetBytes(user), Encoding.ASCII.GetBytes(passwd));

            if (authResponse.Error_code != 0)
            {
                throw new Exception("error auth!");
            }

            return authResponse;
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ExecutionResponse> ExecuteAsync(long sessionID, string statement)
        {
            var executionResponse = await Client.execute(sessionID, Encoding.UTF8.GetBytes(statement));
            if (executionResponse.Error_code != 0)
            {
                throw new Exception(Encoding.UTF8.GetString(executionResponse.Error_msg) + statement + " execute failed.");
            }

            return executionResponse;
        }
        /// <summary>
        /// 连接是否是可用的
        /// </summary>
        /// <returns></returns>
        public async Task<bool> PingAsync()
        {
            try
            {
                await ExecuteAsync(0, "YIELD 1;");

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 释放 sessionId
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public async Task SignOutAsync(long sessionId)
        {
            await Client.signout(sessionId);
        }
        /// <summary>
        /// 释放连接
        /// </summary>
        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
