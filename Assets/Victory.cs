using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private TMPro.TextMeshProUGUI PassedWaves;
    [SerializeField] private TMPro.TextMeshProUGUI Level;
    /// <summary>
    /// Restart a played map and set everything on the map to it's default.
    /// </summary>
    
    private void Start()
    {
        PassedWaves.text = GameStats.Wave.ToString();
        Level.text = LoadingScreen.MapId.ToString();
    }
    public void LoadNextLevel(){
        if(LoadingScreen.MapId > 16){
            LoadingScreen.MapId += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            nextLevelBtn.interactable = false;
        }
    }
    /// <summary>
    /// Close <c>PlayScene</c> and switch to <c>MainMenuScene</c>.
    /// </summary>
    public void MenuClick(){
        SceneManager.LoadScene(0);
    }
}
