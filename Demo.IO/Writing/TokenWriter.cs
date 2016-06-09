using System.IO;

namespace Demo.IO.Writing
{
    abstract public class TokenWriter
    {
        protected TokenWriter(BinaryWriter writer)
        {
            Writer = writer;
        }

        public abstract void WriteDiscriminator(int value);

        protected BinaryWriter Writer { get; }
    }
}