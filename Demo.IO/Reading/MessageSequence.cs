using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    public class MessageSequence : IObservable<object>
    {
        public MessageSequence(TokenReader reader)
        {
            Reader = reader;
            Subject = new Subject<object>();
            RunAsync();
        }

        public IDisposable Subscribe(IObserver<object> observer) =>
            Subject.Subscribe(observer);

        Task RunAsync() =>
            Task.Run(() =>
            {
                try
                {
                    object e = null;
                    using (Reader)
                        while (TryRead(out e))
                            Subject.OnNext(e);

                    Subject.OnCompleted();
                }
                catch (Exception ex)
                {
                    Subject.OnError(ex);
                }
            });

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
        Subject<object> Subject { get; }
    }
}
