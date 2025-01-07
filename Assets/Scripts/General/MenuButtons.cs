using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public GameObject settingsMenu, creditsMenu, difficultyButton;
    private bool isHard = false;

    private DifficultyManager difficulty;
    public DifficultyManager difficultyPrefab;

    private void Start()
    {
        if (FindObjectOfType<DifficultyManager>() == null) Instantiate(difficultyPrefab);
        difficulty = FindObjectOfType<DifficultyManager>();
        isHard = difficulty.isHard;
        if (isHard && difficultyButton != null) difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Difficulty: Hard";
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

    public void ChangeDifficulty()
    {
        if (isHard) difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Difficulty: Easy";
        else difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Difficulty: Hard";

        difficulty.ChangeDifficulty();

        isHard = !isHard;
    }

    public void OpenCredits()
    {
        creditsMenu.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
