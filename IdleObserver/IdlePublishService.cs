using System.Collections.Concurrent;

namespace PubSub;

public class IdlePublishService : IIdlePublishService
{
    private readonly ConcurrentBag<IObserver<IdleEvent>> _observers = new();

    public IDisposable Subscribe(IObserver<IdleEvent> observer)
    {
        _observers.Add(observer);

        // нужно вернуть IDisposable, в котором будет реализована отписка 
        return null;
    }

    public void Timer()
    {
        foreach (var observer in _observers)
        {
            // отправляем время простоя слушателям
            observer.OnNext(new IdleEvent());
        }
    }
}