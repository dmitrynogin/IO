using Demo.IO.Reading;
using Demo.IO.Writing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO
{
    public abstract class IOClient
    {
        protected IOClient(TokenWriter writer, TokenReader reader)
        {
            Writer = writer;
            Dispatcher = new MessageDispatcher(
                new MessageReader(reader));
        }
        
        protected TokenWriter Writer { get; }
        protected IMessageDispatcher Dispatcher { get; }
    }
}
