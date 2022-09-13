
using PacMan.SceneManagement;
using UnityEngine;
using Zenject;

namespace PacMan.UI
{
    public class MainMenuView : MonoBehaviour, MainMenuViewInput
    {
        private ISceneManager sceneManager;

        [Inject]
        void Inject(ISceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
        }

        public void StartGame()
        {
            sceneManager.LoadScene(Keys.Key.GAME_SCENE_NAME);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
