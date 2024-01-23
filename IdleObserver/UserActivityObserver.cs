namespace PubSub;

public class UserActivityObserver : IObserver<IdleEvent>
{
    private readonly Action _onNotWork;
    private readonly Action _onWork;
    private readonly TimeSpan _timeout;
    private DateTime _lastCheckTime = DateTime.Now;

    public UserActivityObserver(Action onWork, Action onNotWork, TimeSpan timeout)
    {
        _onWork = onWork;
        _onNotWork = onNotWork;
        _timeout = timeout;
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(IdleEvent value)
    {
        if (DateTime.Now - _lastCheckTime >= _timeout)
        {
            _lastCheckTime = DateTime.Now;

            if (value.Idle >= _timeout)
            {
                _onNotWork();
            }
            else
            {
                _onWork();
            }
        }
    }
}