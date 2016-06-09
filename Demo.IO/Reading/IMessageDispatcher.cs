using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.IO.Reading
{
    public interface IMessageDispatcher
    {
        IDisposable Subscribe<T>(Predicate<T> predicate, Func<T, bool> handler);
    }

    public static class MessageDispatherExtentions
    {
        public static IDisposable Subscribe<T>(
            this IMessageDispatcher dispatcher, 
            Action<T> handler, 
            bool keep = false) =>
            dispatcher.Subscribe(m => true, handler, keep);

        public static IDisposable Subscribe<T>(
            this IMessageDispatcher dispatcher, 
            Predicate<T> predicate, 
            Action<T> handler, 
            bool keep = false) =>
            dispatcher.Subscribe(predicate, m => { handler(m); return keep; });

        public static IDisposable Subscribe<T>(
            this IMessageDispatcher dispatcher, 
            Func<T, bool> handler) =>
            dispatcher.Subscribe(m => false, handler);
    }
}
