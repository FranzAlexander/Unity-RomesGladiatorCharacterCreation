using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public Button newGameButton;
    public Button backToMainMenu;
    public Button startGameButton;
    public Button quitGame;

    string sceneLoaded;
    Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        sceneLoaded = currentScene.name;

        if (sceneLoaded == "MainMenu")
        {
            newGameButton.onClick.AddListener(NewGameTask);
            quitGame.onClick.AddListener(QuitGameTask);
            gameObject.GetComponent<CharacterCreation>().enabled = false;
            gameObject.GetComponent<Toggles>().enabled = false;
        }

        if (sceneLoaded == "CharacterCreation")
        {
            backToMainMenu.onClick.AddListener(BackToMainMenu);
            startGameButton.onClick.AddListener(StartGameTask);
            gameObject.GetComponent<CharacterCreation>().enabled = true;
            gameObject.GetComponent<Toggles>().enabled = true;
        }

        if (sceneLoaded == "Game")
        {
            backToMainMenu.onClick.AddListener(BackToCharacterCreate);
            gameObject.GetComponent<CharacterCreation>().enabled = false;
            gameObject.GetComponent<Toggles>().enabled = false;
        }
    }

    void NewGameTask()
    {
        SceneManager.LoadScene("CharacterCreation");
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void StartGameTask()
    {
        SceneManager.LoadScene("Game");
    }

    void BackToCharacterCreate()
    {
        SceneManager.LoadScene("CharacterCreation");
    }

    void QuitGameTask()
    {
        Application.Quit();
    }
}