using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        Container.DeclareSignal<GameStateChangedSignal>().OptionalSubscriber();
    }
}