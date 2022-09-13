using PacMan.Keys;
using PacMan.Keys.UI;
using PacMan.SceneManagement;
using UnityEngine;
using Zenject;

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
        sceneManager.LoadScene(Keys.GAME_SCENE_NAME);
    }

    public void Quit()
    {
       Application.Quit();
    }
}