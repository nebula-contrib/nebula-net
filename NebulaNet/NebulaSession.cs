using Nebula.Graph;
using System;
using System.Threading.Tasks;

namespace NebulaNet
{
    public class NebulaSession
    {
        private readonly long sessionID;
        private NebulaConnection? _connection = null;
        private readonly NebulaConnPool _connPool;
        public NebulaSession(long sessionId, NebulaConnection connection, NebulaConnPool connPool)
        {
            sessionID = sessionId;
            _connection = connection;
            _connPool = connPool;
        }

        public async Task<ExecutionResponse> ExecuteAsync(string statement)
        {
            if (_connection == null)
            {
                throw new InvalidOperationException("The session was released, couldn't use again.");
            }
            var executionResponse = await _connection.ExecuteAsync(sessionID, statement);

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
        public async Task ReleaseAsync()
        {
            if (_connection == null)
            {
                return;
            }
            await _connection.SignOutAsync(sessionID);
            _connPool.ReturnConnect(_connection);
        }
    }
}
