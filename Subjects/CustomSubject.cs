

using DemoObserverPattern.ObjectTypes;

namespace DemoObserverPattern.Subjects;
    public abstract class CustomSubject<T> 
    {
        private List<IObserver<T>> _observers = new List<IObserver<T>>();

        public void AddObserver(IObserver<T> playerObserver)
        {
            _observers.Add(playerObserver);
        }

        public void RemoveObserver(IObserver<T> playerObserver)
        {
            _observers.Remove(playerObserver);
        }


        protected void NotifyObservers(T subjectValue)
        {
            _observers.ForEach((_observer) =>
            {
                _observer.OnNext(subjectValue);
            });
        }
}

