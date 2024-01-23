namespace PubSub;

public class PhotoControlActivityObserver : IObserver<IdleEvent>
{
    private readonly Action _onNotWork;

    public PhotoControlActivityObserver(Action onNotWork)
        => _onNotWork = onNotWork;

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
        _onNotWork();
    }
}