using Demo.IO.Reading;
using Demo.IO.Writing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.IO
{
    public abstract class IOClient
    {
        protected IOClient(TokenWriter writer, TokenReader reader)
        {
            Writer = writer;

            var subject = new Subject<object>();
            Task.Run(() =>
            {
                foreach (var item in new MessageReader(reader))
                    subject.OnNext(item);
            });
            Reader = subject;            
        }
        
        protected TokenWriter Writer { get; }
        protected IObservable<object> Reader { get; }
    }
}
