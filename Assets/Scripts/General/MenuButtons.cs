using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    private GameObject settingsMenu;

    private void Start()
    {
        settingsMenu = GameObject.Find("Settings");
        settingsMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
