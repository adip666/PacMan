namespace PacMan.SceneManagement
{
    public interface ISceneManager
    {
        void LoadScene(string sceneToLoad);

        void RestartGame();
    }
}