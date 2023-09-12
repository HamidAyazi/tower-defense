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

    public void OpenSetting(){
        MenuPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }

    public void CloseSetting(){
        SettingPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
