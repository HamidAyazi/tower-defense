using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    /// <summary>
    /// Pause the game and open Pause Menu.
    /// </summary>
    public void PauseGame() {
        SoundManager.PlaySound(Sound.ButtonClick);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Close Pause Manu and resume the game.
    /// </summary>
    public void ContinueGame() {
        SoundManager.PlaySound(Sound.ButtonClick);
        PausePanel.SetActive(false);
        Time.timeScale = SpeedManager.Speed;
    }

    /// <summary>
    /// Restart a played map and set everything on the map to it's default.
    /// </summary>
    public void RetryClick(){
        SoundManager.PlaySound(Sound.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Close <c>PlayScene</c> and switch to <c>MainMenuScene</c>.
    /// </summary>
    public void EndGameClick(){
        SoundManager.PlaySound(Sound.ButtonClick);
        Debug.Log("end game clicked");
    }

    /// <summary>
    /// Close <c>PlayScene</c> and switch to <c>MainMenuScene</c>.
    /// </summary>
    public void MenuClick()
    {
        // TODO - Save Current play session
        SoundManager.PlaySound(Sound.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
