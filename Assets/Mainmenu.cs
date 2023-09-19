using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject TalentPanel;
    public void OpenLevels(){
        SceneManager.LoadScene(1);
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
