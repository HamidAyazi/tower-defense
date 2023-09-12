using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    public void PauseGame() {
        SoundManager.PlaySound(Sound.ButtonClick);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame() {
        SoundManager.PlaySound(Sound.ButtonClick);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RetryClick(){
        SoundManager.PlaySound(Sound.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGameClick(){
        SoundManager.PlaySound(Sound.ButtonClick);
        Debug.Log("end game clicked");
    }

    public void MenuClick(){
        // TODO - Save Current play session
        SoundManager.PlaySound(Sound.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
