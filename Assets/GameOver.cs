using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;

    private void Start()
    {
        Goal.OnGoalDied += GameOverProcess;
    }

    private void GameOverProcess(object sender, System.EventArgs e)
    {
        Debug.Log(GameOverPanel);
        // Stop the game
        Time.timeScale = 0;
        // Open game over panel
        GameOverPanel.SetActive(true);
        // Play game over sound
        SoundManager.PlaySound(Sound.GameOver);
    }

    /// <summary>
    /// Restart a played map and set everything on the map to it's default.
    /// </summary>
    public void RetryClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Close <c>PlayScene</c> and switch to <c>MainMenuScene</c>.
    /// </summary>
    public void MenuClick(){
        SceneManager.LoadScene(0);
    }
}
