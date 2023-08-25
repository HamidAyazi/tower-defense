using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private int Speed = 1;

    public void ChangeSpeed(){
        Debug.Log("Hi");
        if(Speed == 1){
            X2Speed();
        } else if (Speed == 2){
            X3Speed();
        } else if (Speed == 3){
            X1Speed();
        }
    }
    private void X2Speed() {
        Speed = 2;
        Time.timeScale = 2;
    }

      private void X3Speed() {
        Speed = 3;
        Time.timeScale = 3;
    }

      private void X1Speed() {
        Speed = 1;
        Time.timeScale = 1;
    }
}
