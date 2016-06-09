using Demo.IO.Freescale.TurboGadget.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Freescale.TurboGadget
{
    public class TemperatureReport
    {
        public TemperatureReport(TurboGadgetReader reader)
            : this(
                 board: reader.ReadTemperature(),
                 ambient: reader.ReadTemperature())
        {
        }

        public TemperatureReport(float board, float ambient)
        {
            Board = board;
            Ambient = ambient;
        }

        public float Board { get; }
        public float Ambient { get; }
    }
}
