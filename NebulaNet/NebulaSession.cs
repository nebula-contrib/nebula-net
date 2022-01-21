using Nebula.Graph;
using System;
using System.Threading.Tasks;

namespace NebulaNet
{
    public class NebulaSession
    {
        private readonly SessionId _session;
        private NebulaConnection? _connection = null;
        private readonly NebulaConnPool _connPool;
        public NebulaSession(SessionId session, NebulaConnection connection, NebulaConnPool connPool)
        {
            _session = session;
            _connection = connection;
            _connPool = connPool;
        }

        public async Task<ExecutionResponse> ExecuteAsync(string statement)
        {
            if (_connection == null)
            {
                throw new InvalidOperationException("The session was released, couldn't use again.");
            }
            var executionResponse = await _connection.ExecuteAsync(_session.Id, statement);

            return executionResponse;
        }
        /// <summary>
        /// 重新获取连接
        /// </summary>
        /// <returns></returns>
        public void RefreshAsync()
        {
            if (_connection!=null)
            {
                _connPool.ReturnConnect(_connection);
            }
            _connection = _connPool.GetConnect();
        }
        public async Task<bool> PingAsync()
        {
            if (_connection == null)
            {
                return false;
            }
            return await _connection.PingAsync();
        }
        /// <summary>
        /// 释放session
        /// </summary>
        /// <returns></returns>
        public void Release()
        {
            if (_connection == null)
            {
                return;
            }
            _connPool.ReturnConnect(_connection);
            _connPool.ReturnSessionId(_session);
        }
    }
}
