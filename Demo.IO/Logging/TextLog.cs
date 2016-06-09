using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Logging
{
    public class TextLog : Log
    {
        public TextLog(TextWriter writer)
        {
            Writer = writer;
        }

        public override void Dispose() =>
            Writer.Dispose();

        public override void Write(string line) =>
            Writer.WriteLine(line);

        TextWriter Writer { get; }
    }
}
