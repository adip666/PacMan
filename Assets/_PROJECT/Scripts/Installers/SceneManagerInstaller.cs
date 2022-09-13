using PacMan.SceneManagement;
using Zenject;

namespace PacMan.Installers
{
    public class SceneManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneManager>().To<SceneManager>().AsSingle();

        }
    }
}