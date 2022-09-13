using PacMan.Keys;
using PacMan.SceneManagement;
using TMPro;
using UnityEngine;
using Zenject;

namespace PacMan.UI
{
    public class EndGameView : MonoBehaviour, IEndGameView, EndGameViewInput
    {
        [Inject] private ISceneManager sceneManager;
        [SerializeField] private Transform content;
        [SerializeField] private TextMeshProUGUI gameResultText;

        public void RestartGame()
        {
            PlayerPrefs.SetInt(Key.LEVEL_PREFS_NAME, 1);
            sceneManager.RestartGame();
        }

        public void BackToMenu()
        {
            sceneManager.LoadScene(Key.MAIN_MENU_SCENE_NAME);
        }

        public void ExitToWindows()
        {
            
            Application.Quit();
        }

        public void ShowWinPanel()
        {
            gameResultText.text = "You Win";
            gameResultText.color = Color.green;
            content.gameObject.SetActive(true);
        }

        public void ShowLosePanel()
        {
            gameResultText.text = "You Lose";
            gameResultText.color = Color.red;
            content.gameObject.SetActive(true);
        }

       
    }
}