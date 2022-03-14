using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNet
{
    public class NebulaSessionIdPoolPolicy : IPooledObjectPolicy<SessionId>
    {
        public SessionId Create()
        {
            return new SessionId();
        }

        public bool Return(SessionId obj)
        {
            if (obj.IsValid)
                return true;
            return false;
        }
    }
}
