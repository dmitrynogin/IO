using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    public class Dispatcher : IObservable<object>
    {
        public Dispatcher(IEnumerable source)
        {
            Source = source;
            Subject = new Subject<object>();
            Task = new Task(Run);
        }
        
        public IDisposable Subscribe(IObserver<object> observer) =>
            Subject.Subscribe(observer);

        public void Enable() =>
            Task.Start();

        void Run()
        {
            try
            {
                foreach (var e in Source)
                    Subject.OnNext(e);

                Subject.OnCompleted();
            }
            catch (Exception ex)
            {
                Subject.OnError(ex);
            }
        }                
        
        IEnumerable Source { get; }
        Subject<object> Subject { get; }
        Task Task { get; }
    }
}
