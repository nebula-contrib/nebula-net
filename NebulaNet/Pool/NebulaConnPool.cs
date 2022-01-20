using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NebulaNet
{
    public class NebulaConnPool
    {
        private readonly ObjectPool<NebulaConnection> _objectPool;
        private readonly NebulaConfig _nebulaConfig;
        public NebulaConnPool(ObjectPool<NebulaConnection> objectPool, NebulaConfig nebulaConfig)
        {
            _objectPool = objectPool;
            _nebulaConfig = nebulaConfig;
        }

        public async Task<NebulaSession> GetSessionAsync()
        {
            var connection = _objectPool.Get();
            var authResponse = await connection.AuthenticateAsync(_nebulaConfig.UserName, _nebulaConfig.Password);

            return new NebulaSession(authResponse.Session_id, connection,this);
        }

        public void ReturnConnect(NebulaConnection connection)
        {
            _objectPool.Return(connection);
        }

        public NebulaConnection GetConnect()
        {
            return _objectPool.Get();
        }
    }
}
