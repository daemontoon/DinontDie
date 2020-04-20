using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoose : MonoBehaviour
{
    public static bool GameIsEnd = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Dino").Length <= 0)
        {
                EndPause();
        }

    }
    public void EndResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsEnd = false;
    }

    void EndPause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsEnd = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
