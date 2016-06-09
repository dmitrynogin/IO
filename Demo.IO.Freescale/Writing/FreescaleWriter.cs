using Demo.IO.Writing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Demo.IO.Freescale.Writing
{
    public abstract class FreescaleWriter : TokenWriter
    {
        protected FreescaleWriter(BinaryWriter writer) 
            : base(writer)
        {
        }

        public override void WriteDiscriminator(int value) =>
            Writer.WriteBE(value);


    }
}
