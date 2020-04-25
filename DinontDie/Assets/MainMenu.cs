using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;

    public Image fade;
    private void Awake()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
    public void PlayGame ()
    {
        StartCoroutine(FadeAudioSource.StartFade(audioSource, 2, 0));

        StartCoroutine(FadeImage());

    }
    public void QuitGame ()
    {

        Debug.Log ("Quit");
        Application.Quit();
        {
            
        }
    }
    public static class FadeAudioSource
    {

        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }
    IEnumerator FadeImage()
    {
        // fade from opaque to transparent

        // loop over 1 second backwards
        /* for (float i = 1; i >= 0; i -= Time.deltaTime)
         {
             // set color with i as alpha
             fade.color = new Color(1, 1, 1, i);
             yield return null;
         }
     SceneManager.LoadScene("Test Scene");
     // fade from transparent to opaque

     // loop over 1 second
     */
        for (float i = 0; i <= 2; i += Time.deltaTime)
        {
            fade.gameObject.SetActive(true);

            // set color with i as alpha
            fade.color = new Color(0,0, 0, i);
            Debug.Log("ici");
            yield return null;

        }
        SceneManager.LoadScene("Test Scene");


    }
}
