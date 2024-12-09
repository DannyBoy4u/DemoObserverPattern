using DemoObserverPattern.ObjectTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace DemoObserverPattern.Subjects
{
    public class PlayerActionTracker : ISubject<PlayerAction>
    {
        private List<IObserver<PlayerAction>> observers = new List<IObserver<PlayerAction>>();
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(PlayerAction value)
        {
            observers.ForEach(observer => observer.OnNext(value));
        }

        public IDisposable Subscribe(IObserver<PlayerAction> observer)
        {
            observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<PlayerAction>> _observers;
            private IObserver<PlayerAction> _observer;

            public Unsubscriber(List<IObserver<PlayerAction>> observers, IObserver<PlayerAction> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
