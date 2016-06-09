using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    public class Protocol
    {
        public static readonly Protocol Undefined = new Protocol(ImmutableDictionary<int, Type>.Empty);

        Protocol(IImmutableDictionary<int, Type> types)
        {
            Types = types;
        }

        public Protocol Support<TEvent>(int discriminator) =>
            new Protocol(Types.Add(discriminator, typeof(TEvent)));

        public Type this[int discriminator]
        {
            get
            {
                if (!Types.ContainsKey(discriminator))
                    throw new NotSupportedException();

                return Types[discriminator];
            }
        }

        IImmutableDictionary<int, Type> Types { get; }
    }
}
