using Demo.IO;
using Demo.IO.Freescale;
using Demo.IO.Freescale.TurboGadget;
using Demo.IO.Freescale.TurboGadget.Reading;
using Demo.IO.Logging;
using Demo.IO.Reading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                var binaryReader = new BinaryReader(Echo.Stream);
                var tokenReader = new TurboGadgetReader(binaryReader, Log.Console);
                foreach (dynamic e in new MessageReader(tokenReader))
                    Handle(e);
            });

            while (true)
                SendEvent();
        }

        static void Handle(SessionStart e) =>
            Console.WriteLine("(SessionStart event)");

        static void Handle(TemperatureReport e) =>
            Console.WriteLine("(TemperatureReport event)");

        static void SendEvent()
        {
            Console.WriteLine("Sending an event...");
            using (var w = new BinaryWriter(Echo.Stream, Encoding.ASCII, true))
            {
                w.WriteBE(1); // sessionstart 
                w.WriteBE(2); // 2.3
                w.WriteBE(3);
                w.WriteBE(4); // 4.5
                w.WriteBE(5);
                w.Write((byte)1); // channels
                w.Write((byte)2);
                w.Write((byte)0);
            }             
                       
            Console.ReadLine();
        }
    }
}
