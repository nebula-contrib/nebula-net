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
                var objectPoolProvider = new DefaultObjectPoolProvider();
                objectPoolProvider.MaximumRetained = 30;
                return objectPoolProvider.Create(new NebulaConnPoolPolicy(config));
            });
            services.AddSingleton<ObjectPool<SessionId>>(serviceProvider =>
            {
                var objectPoolProvider=new DefaultObjectPoolProvider();
                objectPoolProvider.MaximumRetained = 30;
                return objectPoolProvider.Create(new NebulaSessionIdPoolPolicy());
            });
            services.AddSingleton(serviceProvider =>
            {
                var connPool = serviceProvider.GetRequiredService<ObjectPool<NebulaConnection>>();
                var sessionIdPool = serviceProvider.GetRequiredService<ObjectPool<SessionId>>();
                return new NebulaPool(connPool, sessionIdPool, config);
            });

            return services;
        }
    }
}
