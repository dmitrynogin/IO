using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    interface ISubscription : IDisposable
    {
        void Notify(object message);
    }
}
