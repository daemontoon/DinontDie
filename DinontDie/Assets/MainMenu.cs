using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image fade;
    private void Awake()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
    public void PlayGame ()
    {


        StartCoroutine(FadeImage());

    }
    public void QuitGame ()
    {

        Debug.Log ("Quit");
        Application.Quit();
        {
            
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
