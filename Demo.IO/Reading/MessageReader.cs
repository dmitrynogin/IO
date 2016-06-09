using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    public class MessageReader : IEnumerable
    {
        public MessageReader(TokenReader reader)
        {
            Reader = reader;
        }

        public IEnumerator GetEnumerator()
        {
            object e = null;
            using (Reader)
                while (TryRead(out e))
                    yield return e;
        }

        bool TryRead(out object e)
        {
            try
            {
                var type = Reader.ReadDiscriminator();
                e = Activator.CreateInstance(type, Reader);
                return true;
            }
            catch (ObjectDisposedException)
            {
                e = null;
                return false;
            }
        }

        TokenReader Reader { get; }
    }
}
