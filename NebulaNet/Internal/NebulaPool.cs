using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNet
{
    public class NebulaPool
    {
        private readonly ObjectPool<NebulaConnection> _objectPool;
        private readonly NebulaConfig _nebulaConfig;
        public NebulaPool(ObjectPool<NebulaConnection> objectPool, NebulaConfig nebulaConfig)
        {
            _objectPool = objectPool;
            _nebulaConfig = nebulaConfig;
        }

        public NebulaClient GetClient()
        {
            var connection = _objectPool.Get();
            var authResponse = connection.Authenticate(_nebulaConfig.UserName, _nebulaConfig.Password);

            return new NebulaClient(connection, authResponse);
        }

        public void ReturnClient(NebulaConnection connection)
        {
            _objectPool.Return(connection);
        }
    }
}
