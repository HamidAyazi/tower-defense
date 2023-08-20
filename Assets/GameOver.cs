using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Goal goal;
    [SerializeField] private GameObject GameOverPanel;
    void Start()
    {
        goal.OnGoalDied += GameOverProcess;
    }


    private void GameOverProcess(object sender, System.EventArgs e)
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RetryClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuClick(){
        Debug.Log("menu clicked");
    }
}
