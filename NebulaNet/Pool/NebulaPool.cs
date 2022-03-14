using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NebulaNet
{
    public class NebulaPool
    {
        private readonly ObjectPool<NebulaConnection> _connPool;
        private readonly NebulaConfig _nebulaConfig;
        private readonly ObjectPool<SessionId> _sessionIdPool;
        public NebulaPool(ObjectPool<NebulaConnection> objectPool,
            ObjectPool<SessionId> sessionIdPool,
            NebulaConfig nebulaConfig)
        {
            _connPool = objectPool;
            _nebulaConfig = nebulaConfig;
            _sessionIdPool = sessionIdPool;
        }

        public async Task<NebulaSession> GetSessionAsync()
        {
            var connection = _connPool.Get();

            var session = _sessionIdPool.Get();
            if (!session.IsValid || session.Id <= 0)
            {
                var authResponse = await connection.AuthenticateAsync(_nebulaConfig.UserName, _nebulaConfig.Password);
                session.SetId(authResponse.Session_id);
            }

            return new NebulaSession(session, connection,this);
        }

        public void ReturnConnect(NebulaConnection connection)
        {
            _connPool.Return(connection);
        }

        public void ReturnSessionId(SessionId sessionId)
        {
            _sessionIdPool.Return(sessionId);
        }

        public NebulaConnection GetConnect()
        {
            return _connPool.Get();
        }
    }
}
