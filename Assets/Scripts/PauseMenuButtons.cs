using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    public Button ContinueButton;
    public Button OptionsButton;
    public Button ExitToMenuButton;

    public GameObject PauseScreen;
    public GameObject OtherUI;
    public GameObject PlayerObject;

    private void Awake()
    {
        ContinueButton.onClick.AddListener(ContinueButtonPressed);
        ExitToMenuButton.onClick.AddListener(OnExitToMenu);

        Events.OnGamePaused += OnPause;
        Events.OnGameUnPaused += OnUnPause;
    }

    private void OnDestroy()
    {
        Events.OnGamePaused -= OnPause;
        Events.OnGameUnPaused -= OnUnPause;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && PauseScreen.activeSelf == false)
        {
            Events.PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && PauseScreen.activeSelf == true)
        {
            Events.UnPauseGame();
        }
    }
    public void ContinueButtonPressed()
    {
        Events.UnPauseGame();
    }
    public void OnPause()
    {
        print("game paused");
        Time.timeScale = 0;

        PlayerObject.SetActive(false);
        Cursor.visible = true;
        OtherUI.SetActive(false);
        PauseScreen.SetActive(true);
    }
    public void OnUnPause()
    {
        print("resume game");
        Time.timeScale = 1.0f;
        PlayerObject.SetActive(true);
        Cursor.visible = false;
        OtherUI.SetActive(true);
        PauseScreen.SetActive(false);
    }
    public void OnExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
