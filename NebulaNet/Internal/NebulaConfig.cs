using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNet
{
    public class NebulaConfig
    {
        public NebulaConfig(string ip= "0.0.0.0",int port= 9669,string userName="root",string password="nebula",int maxConnsSize = 5)
        {
            Ip=ip;
            Port = port;
            UserName = userName;
            Password = password;
            MaxConnsSize = maxConnsSize;
        }
        public string Ip { get;private set; }
        public int Port { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int MaxConnsSize { get; private set; }
    }
}
