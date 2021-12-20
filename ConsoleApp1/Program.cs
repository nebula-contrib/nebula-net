using System;
using Thrift;
using Thrift.Transport.Client;
using Thrift.Protocol;
using Nebula.Graph;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class GraphClient
    {
        private TSocketTransport socketTransport { get; set; }
        private TBinaryProtocol protocolProtocol { get; set; }

        public GraphClient(string ip, int port)
        {
            var tConfiguration = new TConfiguration();
            socketTransport = new TSocketTransport(ip, port, tConfiguration);
            //var transport2 = new TMemoryBufferTransport(tConfiguration);

            socketTransport.OpenAsync(default);

            protocolProtocol = new TBinaryProtocol(socketTransport);

            var client = new GraphService.Client(protocolProtocol);
        }
    }
}