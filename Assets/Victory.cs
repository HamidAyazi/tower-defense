using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject VicotryPanel;
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private TMPro.TextMeshProUGUI PassedWaves;
    [SerializeField] private TMPro.TextMeshProUGUI Level;
    
    private void OnEnable()
    {
        PassedWaves.text = GameStats.Wave.ToString();
        Level.text = LoadingScreen.MapId.ToString();
    }

    /// <summary>
    /// Restart Scene with next level ID
    /// </summary>
    public void LoadNextLevel(){
        if(LoadingScreen.MapId > 16){
            LoadingScreen.MapId += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            nextLevelBtn.interactable = false;
        }
    }

    /// <summary>
    /// Close <c>GameScene</c> and switch to <c>MainMenuScene</c>.
    /// </summary>
    public void MenuClick(){
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Pause game and show Victory UI
    /// </summary>
    public void ShowVictoryPanel()
    {
        Time.timeScale = 0;
        VicotryPanel.SetActive(true);
        SoundManager.PlaySound(Sound.Victory);
    }
}
