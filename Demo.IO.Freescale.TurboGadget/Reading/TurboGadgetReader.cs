using Demo.IO.Freescale.Reading;
using Demo.IO.Logging;
using Demo.IO.Reading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Freescale.TurboGadget.Reading
{
    public class TurboGadgetReader : FreescaleReader
    {
        public TurboGadgetReader(BinaryReader reader, Log log)
            : base(reader, log)
        {
        }

        protected override Protocol Protocol => base.Protocol
            .Support<TemperatureReport>(2);

        public virtual float ReadTemperature() =>
            Token("temperature",
                Reader.ReadSingleBE());
    }
}
