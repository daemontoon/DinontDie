using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeLevel : MonoBehaviour
{
    public static bool levelChanging = false;
    public GameObject pauseMenuUI;
    public TMP_Text titreEpoque;
    public Sprite[] visuel;
    public Image level;
    // Update is called once per frame


    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            if (levelChanging) Resume();
        }

    }
    public void Resume()
    {
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        levelChanging = false;
    }

    void Pause()
    {
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        levelChanging = true;
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
    void DestroyAll(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void changeLevel(int numero)
    {

        Debug.Log("LOL");
        level.sprite = visuel[numero-1];
        DestroyAll("Meteor");
        DestroyAll("Volcan");
        Pause();

    }
}
