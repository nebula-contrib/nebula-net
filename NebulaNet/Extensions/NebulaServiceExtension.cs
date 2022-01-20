using Microsoft.Extensions.ObjectPool;
using NebulaNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class NebulaServiceExtension
    {
        public static IServiceCollection AddNebulaGraph(this IServiceCollection services, NebulaConfig config)
        {
            services.AddSingleton<ObjectPool<NebulaConnection>>(serviceProvider =>
            {
                return new DefaultObjectPoolProvider().Create(new NebulaConnPoolPolicy(config));
            });
            services.AddSingleton(serviceProvider =>
            {
                var objectPool = serviceProvider.GetRequiredService<ObjectPool<NebulaConnection>>();
                return new NebulaConnPool(objectPool, config);
            });

            return services;
        }
    }
}
