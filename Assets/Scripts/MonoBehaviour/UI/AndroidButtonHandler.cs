using UnityEngine;

public class AndroidButtonHandler : MonoBehaviour
{
    [SerializeField] private int ActivePanelID;

    private bool ExitConfirm = false;
    private float ExitTimer = 2f;

    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ActivePanelID == 0)
            {
                if (ExitConfirm)
                {
                    GetComponentInParent<Mainmenu>().ExitGame();
                }
                ShowToast("Press Back again to exit.");
                ExitConfirm = true;
            }
            if (ActivePanelID == 1)
            {
                GetComponentInParent<Mainmenu>().CloseSetting();
            }
            if (ActivePanelID == 2)
            {
                GetComponentInParent<Mainmenu>().CloseTalents();
            }
            if (ActivePanelID == 3)
            {
                GetComponentInParent<Mainmenu>().CloseLevels();
            }
        }
    }

    // This method will display a Toast message
    private void ShowToast(string message)
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
    
}
