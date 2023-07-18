using Nebula.Graph;
using System;
using System.Threading.Tasks;

namespace NebulaNet
{
    public class NebulaSession
    {
        private readonly SessionId _session;
        private NebulaConnection? _connection = null;
        private readonly NebulaPool _nebulaPool;

        public NebulaSession(SessionId session, NebulaConnection connection, NebulaPool nebulaPool)
        {
            _session = session;
            _connection = connection;
            _nebulaPool = nebulaPool;
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
        /// Refresh session.
        /// </summary>
        /// <returns></returns>
        public void RefreshAsync()
        {
            if (_connection != null)
            {
                _nebulaPool.ReturnConnect(_connection);
            }
            _connection = _nebulaPool.GetConnect();
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
        /// release session
        /// </summary>
        /// <returns></returns>
        public void Release()
        {
            if (_connection == null)
            {
                return;
            }
            _nebulaPool.ReturnConnect(_connection);
            _nebulaPool.ReturnSessionId(_session);
        }
    }
}