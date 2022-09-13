using SignalsSystem;
using Signals;
using Zenject;

namespace PacMan.Installers
{
    public class SignalSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<ISignalSystem>().To<SignalSystem>().AsSingle();
            BindSignals();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<PlayerLifeChangedSignal>();
            Container.DeclareSignal<PlayerDeadSignal>();
            Container.DeclareSignal<SeedCollectedSignal>();
            Container.DeclareSignal<EndGameSignal>();
        }
    }
}