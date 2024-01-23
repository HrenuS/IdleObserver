// See https://aka.ms/new-console-template for more information

using PubSub;

IIdlePublishService idlePublishService = new IdlePublishService();

var subscribtion = idlePublishService
    .Subscribe(new UserActivityObserver(OnWork, OnIdle, TimeSpan.Parse("00:00:05")));

void OnIdle()
{
    Console.WriteLine("Work");
}

void OnWork()
{
    Console.WriteLine("Not work");
}

// отписываемся от событий
subscribtion.Dispose();

var photoControlSubsribtion = idlePublishService
    .Subscribe(new PhotoControlActivityObserver(OnIdle));
photoControlSubsribtion.Dispose();

//todo: можно сделать какой-то базовый observer, который можно будет использовать в разных местах, а на какие-то особые случае выделять отдельный класс.
// также вполне можно, текущий сервис наследовать от IObserver<IdleEvent>, реализовывать нужные методы и делать так .Subscribe(this); но это будет, то, что я изначально предлагал.