using Demo.IO.Freescale.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Freescale
{
    public class SessionStart
    {
        public SessionStart(FreescaleReader reader)
            : this(
                  hardware: reader.ReadVersion(),
                  firmware: reader.ReadVersion(),
                  availableChannels: reader.ReadChannels())
        {
        }

        public SessionStart(
            Version hardware,
            Version firmware,
            params DataChannel[] availableChannels)
        {
            Hardware = hardware;
            Firmware = firmware;
            AvailableChannels = availableChannels;
        }

        public Version Hardware { get; }
        public Version Firmware { get; }
        public IEnumerable<DataChannel> AvailableChannels { get; }
    }
}
