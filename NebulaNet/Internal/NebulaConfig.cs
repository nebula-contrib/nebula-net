using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNet
{
    public class NebulaConfig
    {
        public string Ip { get;private set; } = "0.0.0.0";
        public int Port { get; set; } = 9669;
        public string UserName { get; set; } = "root";
        public string Password { get; set; } = "nebula";
    }
}
