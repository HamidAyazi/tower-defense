using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject[] steps;
    [SerializeField] private GameObject ContinueBtn;

    private int stepIndex = 0;
    // private float waitTime = 3f;


    private void Start(){
        CheckPhase1();
        
    }
    public void ShowPhase(int index) {
        ContinueBtn.SetActive(true);
        if(index > 0) steps[index -1].SetActive(false);
        steps[index].SetActive(true);
    }


    public void ContinueClick(){
        stepIndex += 1;
        if(stepIndex >= 5){
            ContinueBtn.SetActive(false);
            steps[stepIndex-1].SetActive(false);
        } else {
            ShowPhase(stepIndex);
        }
    }

    public void CheckPhase1(){
        if(PlayerPrefs.GetInt("TutorialStep") == 0){
            PlayerPrefs.SetInt("TutorialStep", 1);
            stepIndex = 0;
            ShowPhase(stepIndex);
        }
    }
    public void CheckPhase2(){
        if(PlayerPrefs.GetInt("TutorialStep") == 1){
            PlayerPrefs.SetInt("TutorialStep", 2);
            stepIndex = 5;
            ShowPhase(stepIndex);
        }
    }

    
    public void CheckPhase3(){
        if(PlayerPrefs.GetInt("TutorialStep") == 2){
            PlayerPrefs.SetInt("TutorialStep", 3);
            stepIndex = 6;
            ShowPhase(stepIndex);
        }
    }
    public void CheckPhase4(){
        if(PlayerPrefs.GetInt("TutorialStep") == 3){
            PlayerPrefs.SetInt("TutorialStep", 4);
            stepIndex = 7;
            ShowPhase(stepIndex);
        }
    }
}
