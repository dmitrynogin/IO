using Demo.IO;
using Demo.IO.Freescale;
using Demo.IO.Freescale.TurboGadget;
using Demo.IO.Freescale.TurboGadget.Reading;
using Demo.IO.Freescale.TurboGadget.Writing;
using Demo.IO.Freescale.Writing;
using Demo.IO.Logging;
using Demo.IO.Reading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static FreescaleClient Client { get; } = new FreescaleClient(
            new TurboGadgetWriter(new BinaryWriter(Echo.Stream)),
            new TurboGadgetReader(new BinaryReader(Echo.Stream), Log.Console));

        static void Main(string[] args)
        {
            Client.Heartbeat += (sender, e) => Console.WriteLine("Heartbeat!");
            Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Subscribe(i => Client.IssueHeartbeat());
            
            while (true)
            {
                Console.ReadLine();
                var t = Client.GetNDataChunks(2);
                Client.IssueDataChunk();
                Client.IssueDataChunk();
                Client.IssueDataChunk();
                Console.WriteLine(t.Result);             
            }
        }
    }
}
