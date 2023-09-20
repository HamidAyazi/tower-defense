using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject TalentPanel;
    [SerializeField] private GameObject LevelsPanel;

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
