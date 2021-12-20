using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNet.Graph.Data
{
    public class HostAddress
    {
        private String host;
        private int port;

        public HostAddress(String host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public String getHost()
        {
            return host;
        }

        public int getPort()
        {
            return port;
        }

        public int hashCode()
        {
            return host.GetHashCode() + port;
        }

        public bool equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is HostAddress)
            {
                HostAddress that = (HostAddress)obj;
                return this.host.Equals(that.host) && this.port == that.port;
            }
            return false;
        }

        public String toString()
        {
            return host + ":" + port;
        }
    }
}