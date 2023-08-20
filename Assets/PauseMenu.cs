using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;

    public void PauseGame() {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame() {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RetryClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGameClick(){
        Debug.Log("end game clicked");
    }

    public void MenuClick(){
        Debug.Log("menu clicked");
    }
}
