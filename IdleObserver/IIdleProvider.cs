namespace PubSub;

public interface IIdleProvider
{
    /// <summary>
    ///     Возвращает время неактивности
    /// </summary>
    /// <returns></returns>
    TimeSpan GetIdle();
}