using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public static int MapId;

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
    /// <param name="id">Id of map</param>
    public void LoadLevel(int id)
    {
        SoundManager.PlaySound(Sound.ButtonClick);
        MapId = id;
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(1));
    }
}
