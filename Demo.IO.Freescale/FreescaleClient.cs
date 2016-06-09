using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.IO.Reading;
using Demo.IO.Writing;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Demo.IO.Freescale
{
    public class FreescaleClient : IOClient
    {
        public FreescaleClient(TokenWriter writer, TokenReader reader) 
            : base(writer, reader)
        {
            Reader
                .OfType<Heartbeat>()
                .Subscribe(h => Heartbeat?.Invoke(this, h));
        }

        public event EventHandler<Heartbeat> Heartbeat;

        public async Task<DataChunk[]> GetNDataChunks(int count = 2) =>
            await Reader
                .OfType<DataChunk>()
                .Take(count)                
                .ToArray();        

        public void IssueHeartbeat() =>
            Writer.WriteDiscriminator(100);

        public void IssueDataChunk() =>
            Writer.WriteDiscriminator(101);
    }
}
