using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    class MessageDispatcher : IMessageDispatcher
    {
        public MessageDispatcher(IEnumerable messages)
        {
            Task.Run(() => 
            {
                foreach (var message in messages)
                    foreach (var subscription in Subscriptions.Keys)
                        subscription.Notify(message);
            });
        }

        public IDisposable Subscribe<T>(Predicate<T> predicate, Func<T, bool> handler)
        {
            var subscription = new Subscription<T>(
                predicate, 
                handler, 
                disposing: s => Subscriptions.TryRemove(s, out s));

            Subscriptions.TryAdd(subscription, subscription);
            return subscription;
        }

        ConcurrentDictionary<ISubscription, ISubscription> Subscriptions { get; } =
            new ConcurrentDictionary<ISubscription, ISubscription>();
    }
}
