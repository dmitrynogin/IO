using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    class Subscription<T> : ISubscription
    {
        public Subscription(
            Predicate<T> predicate,
            Func<T, bool> handler,
            Action<ISubscription> disposing)
        {
            Predicate = predicate;
            Handler = handler;
            Disposing = disposing;
        }

        public void Dispose() => Disposing(this);

        public void Notify(object message)
        {
            if (message is T)
                if (Predicate((T)message))
                    if (!Handler((T)message))
                        Dispose();
        }

        Predicate<T> Predicate { get; }
        Func<T, bool> Handler { get; }
        Action<ISubscription> Disposing { get; }
    }
}
