using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    class Echo 
    {
        public static readonly Stream Stream = 
            new Echo(port: 1234)
                .ClientStream;

        Echo(int port)
        {            
            var listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();
            Task.Run(() =>
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();
                stream.CopyTo(stream);
            });
            {
                Thread.Sleep(500);
                var client = new TcpClient("localhost", port);
                ClientStream = client.GetStream();
            }
        }

        Stream ClientStream { get; }
    }
}
