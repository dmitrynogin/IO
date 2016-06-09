using Demo.IO.Freescale.Writing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Demo.IO.Freescale.TurboGadget.Writing
{
    public class TurboGadgetWriter : FreescaleWriter
    {
        public TurboGadgetWriter(BinaryWriter writer) 
            : base(writer)
        {
        }
    }
}
