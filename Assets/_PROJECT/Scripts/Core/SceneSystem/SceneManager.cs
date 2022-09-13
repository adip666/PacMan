using UnityEngine.SceneManagement;

namespace PacMan.SceneManagement
{
    public class SceneManager : ISceneManager
    {
        public void LoadScene(string sceneToLoad)
        {
           UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneToLoad);
        }

        public void RestartGame()
        {
            LoadScene( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}