public interface IObservablePlayerState
{
    void Suscribe(IObserverPlayerState obs);

    void Unsuscribe(IObserverPlayerState obs);
}
