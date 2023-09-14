using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SettingPanel;
    public void OpenLevels(){
        SceneManager.LoadScene(1);
    }

    public void OpenTalents(){

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
