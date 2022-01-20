using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NebulaNet
{
    public class NebulaConnPoolPolicy : IPooledObjectPolicy<NebulaConnection>
    {
        private readonly NebulaConfig _nebulaConfig;
        public NebulaConnPoolPolicy(NebulaConfig nebulaConfig)
        {
            _nebulaConfig = nebulaConfig;
        }
        private int retryTime = 3;
        public NebulaConnection Create()
        {
            NebulaConnection connection = new NebulaConnection();
            while (retryTime-- > 0)
            {
                try
                {
                    connection.OpenAsync(_nebulaConfig.Ip, _nebulaConfig.Port).Wait();

                    return connection;
                }
                catch (Exception ex)
                {
                    if (retryTime==0)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return null;
        }

        public bool Return(NebulaConnection obj)
        {
            return true;
        }
    }
}
