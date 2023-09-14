using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    private IEnumerator LoadAsynchronously(int SceneIndex){

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        while(!operation.isDone) {
            slider.value = Mathf.Clamp01(operation.progress/ 0.9f) / 2;
            yield return null;
        }
    }

    /// <summary>
    /// Open loading screen and change scene.
    /// </summary>
    /// <param name="SceneIndex">Index of the Scene.</param>
    public void LoadLevel(int SceneIndex)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(SceneIndex));
    }
}
