using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Logging
{
    public abstract class Log : IDisposable
    {
        public static readonly Log Null = new TextLog(TextWriter.Null);
        public static readonly Log Console = new TextLog(System.Console.Out);

        public virtual void Dispose() { }
        public abstract void Write(string line);
    }
}
