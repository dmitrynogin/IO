using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.IO.Reading;
using Demo.IO.Writing;

namespace Demo.IO.Freescale
{
    public abstract class FreescaleClient : IOClient
    {
        public FreescaleClient(TokenWriter writer, TokenReader reader) 
            : base(writer, reader)
        {
            Dispatcher.Subscribe((Heartbeat h) => Heartbeat?.Invoke(this, h), keep: true);
        }

        public event EventHandler<Heartbeat> Heartbeat;

        public Task<DataChunk[]> GetNDataChunks(DataChannel channel, int count=3)
        {
            var tcs = new TaskCompletionSource<DataChunk[]>();
            var dca = new DataChunk[count];
            Dispatcher.Subscribe((DataChunk dc) => 
            {
                dca[--count] = dc;
                if (count == 0)
                    tcs.SetResult(dca);

                return count >= 0; // keep subscription?
            });

            Writer.WriteDiscriminator(2);
            return tcs.Task;
        }
    }
}
