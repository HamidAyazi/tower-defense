using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject TalentPanel;
    [SerializeField] private GameObject LevelsPanel;

    private bool ExitConfirm = false;
    private float ExitTimer = 2f;

    private void Start(){
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = PlayerPrefs.GetInt("FPS");
    }

    private void Update()
    {
        if (ExitConfirm)
        {
            ExitTimer -= Time.deltaTime;
            if (ExitTimer < 0)
            {
                ExitTimer = 2f;
                ExitConfirm = false;
            }
        }
        // Check if the Android back button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ExitConfirm)
            {
                ExitGame();
            }
            ShowToast("Press Back again to exit the game.");
            ExitConfirm = true;
        }
    }

    // This method will display a Toast message
    public void ShowToast(string message)
    {
        // Create an AndroidJavaObject for the UnityPlayer class
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Get the current Android activity
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        // Check if currentActivity is valid
        if (currentActivity != null)
        {
            // Create a Toast message
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            AndroidJavaObject toast = toastClass.CallStatic<AndroidJavaObject>("makeText", currentActivity, message, 0);

            // Show the Toast message
            toast.Call("show");
        }
    }

    /// <summary>
    /// Open levels Menu.
    /// </summary>
    public void OpenLevels(){
        SoundManager.PlaySound(Sound.ButtonClick);
        MenuPanel.SetActive(false);
        LevelsPanel.SetActive(true);
    }

    /// <summary>
    /// close levels Menu.
    /// </summary>
    public void CloseLevels(){
        SoundManager.PlaySound(Sound.ButtonClick);
        LevelsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    
    
    /// <summary>
    /// Open Talents Menu.
    /// </summary>
    public void OpenTalents(){
        SoundManager.PlaySound(Sound.ButtonClick);
        MenuPanel.SetActive(false);
        TalentPanel.SetActive(true);
    }

    /// <summary>
    /// Close Talents Menu.
    /// </summary>
     public void CloseTalents(){
        SoundManager.PlaySound(Sound.ButtonClick);
        TalentPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    /// <summary>
    /// Open Settings Menu.
    /// </summary>
    public void OpenSetting(){
        SoundManager.PlaySound(Sound.ButtonClick);
        MenuPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    /// <summary>
    /// Close Settings Menu.
    /// </summary>
    public void CloseSetting(){
        SoundManager.PlaySound(Sound.ButtonClick);
        SettingPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    /// <summary>
    /// Close the Game.
    /// </summary>
    public void ExitGame(){
        SoundManager.PlaySound(Sound.ButtonClick);
        Application.Quit();
    }
}
