using Demo.IO.Logging;
using Demo.IO.Reading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Freescale.Reading
{
    // big-endian
    public abstract class FreescaleReader : TokenReader
    {
        protected FreescaleReader(BinaryReader reader, Log log)
            : base(reader, log)
        {
        }

        protected override Protocol Protocol => Protocol.Undefined
            .Support<SessionStart>(1);

        public override Type ReadDiscriminator() =>
            Token("discriminator", Protocol[Reader.ReadInt32BE()]);

        public virtual Version ReadVersion() =>
            Token("version",
                new Version(Reader.ReadInt32BE(), Reader.ReadInt32BE()));

        public virtual DataChannel[] ReadChannels() =>
            Token("channels",
                Enumerable.Range(0, int.MaxValue)
                    .Select(i => Reader.ReadByte())
                    .TakeWhile(c => c != 0)
                    .Select(c => (DataChannel)c));
    }
}
