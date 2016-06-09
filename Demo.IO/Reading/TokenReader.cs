using Demo.IO.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    public abstract class TokenReader : IDisposable
    {
        protected TokenReader(BinaryReader reader, Log log)
        {
            Reader = reader;
            Log = log;
        }

        public void Dispose()
        {
            Reader.Dispose();
            Log.Dispose();
        }

        public abstract Type ReadDiscriminator();

        protected T Token<T>(string token, T value)
        {
            Log.Write($"{token}={value}");
            return value;
        }

        protected T[] Token<T>(string token, IEnumerable<T> value)
        {
            var array = value.ToArray();
            Log.Write($"{token}=[{string.Join(",", array)}]");
            return array;
        }

        protected abstract Protocol Protocol { get; }
        protected BinaryReader Reader { get; }
        Log Log { get; }
    }
}
