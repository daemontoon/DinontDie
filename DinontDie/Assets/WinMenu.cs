using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour
{
    public static bool GameIsEnd = false;
    public GameObject pauseMenuUI;
    bool winMenu;


    // Update is called once per frame
    void Update()
    {
        winMenu = GameObject.Find("GameManager").GetComponent<gameManager>().win;

        if (winMenu)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsEnd = false;
        SceneManager.LoadScene("TitleScreen");
    }
    public void QuitGame()
    {
        Application.Quit();

    }
}

