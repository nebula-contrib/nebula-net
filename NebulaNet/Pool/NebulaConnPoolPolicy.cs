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
        public NebulaConnection Create()
        {
            int retryTime = 3;
            NebulaConnection connection = new NebulaConnection();
            while (retryTime-- > 0)
            {
                try
                {
                    connection.OpenAsync(_nebulaConfig.Ip, _nebulaConfig.Port).GetAwaiter().GetResult();

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
