using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject uiMenu;
    //public MainMenu MainMenuScript;
    public TMP_Text UsernameText;
    public static bool GameIsPaused = false;
    //private string username;
    


    // Update is called once per frame
    void Update()
    {
        //Pause when player presses ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Leaves pause menu and goes back to game
        pauseMenuUI.SetActive(false);
        uiMenu.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        //Pauses game and opens pause menu
        pauseMenuUI.SetActive(true);
        uiMenu.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //username = MainMenuScript.getUsername();
        //username = MainMenu.username;
        //UsernameText.SetText(MainMenu.username);
        Debug.Log(MainMenu.username);
    }

    public void LoadMenu()
    {
        //Goes to main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        //Exits game
        Application.Quit();
    }

    //thing to implement, an options menu
    //If there is an options menu, make sure the player can access it through clicking the options button in the PauseMenu located in Canvas

    // Start is called before the first frame update
    void Start()
    {
        UsernameText.SetText(MainMenu.username);
    }


}
