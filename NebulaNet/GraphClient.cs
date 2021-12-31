using Nebula.Graph;
using System;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport.Client;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nebula.Common;
using System.Threading;

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

            socketTransport.OpenAsync(default).Wait();

            protocolProtocol = new TBinaryProtocol(socketTransport);

            Client = new GraphService.Client(protocolProtocol);
        }
        public void Authenticate(string user, string passwd)
        {
  
            var authResponse = Client.authenticate(System.Text.Encoding.ASCII.GetBytes(user), System.Text.Encoding.ASCII.GetBytes(passwd)).Result;
            
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
                throw new Exception(System.Text.Encoding.UTF8.GetString(executionResponse.Error_msg) + statement + " execute failed.");
            }

            return executionResponse;
        }

        public async Task<List<T>> Execute<T>(string statement) where T : class
        {
            var executionResponse = await Execute(statement);
            if (executionResponse.Data == null)
                return default;

            //获取列名
            var columnNames = executionResponse.Data.Column_names
                .Select(x => System.Text.Encoding.UTF8.GetString(x).ToLower()).ToArray();
            
            //查找可用属性和数据索引
            var indexAndProps = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)//BindingFlags.IgnoreCase
                .Select(x => new { Index= Array.IndexOf(columnNames,x.Name.ToLower()),Prop=x })
                .Where(x => x.Index >= 0);

            //映射对象
            var result = new List<T>();
            foreach (var row in executionResponse.Data.Rows)
            {
                var o = Activator.CreateInstance<T>();
                foreach (var item in indexAndProps)
                {
                    item.Prop.SetValue(o, row.Values[item.Index].GetValue(item.Prop.PropertyType));
                }
                result.Add(o);
            }

            return result;
        }

        public async Task SignOff()
        {
            await Client.signout(sessionId);
        }
    }
}