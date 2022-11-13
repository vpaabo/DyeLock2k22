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
    public GameObject SkillScreen;
    public GameObject FPS_UI;
    public GameObject PlayerObject;

    

    private void Awake()
    {
        ContinueButton.onClick.AddListener(ContinueButtonPressed);
        ExitToMenuButton.onClick.AddListener(OnExitToMenu);

        Events.OnGamePaused += OnPause;
        Events.OnGameUnPaused += OnUnPause;

        PauseScreen.SetActive(false);
        SkillScreen.SetActive(false);
        FPS_UI.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.K) && SkillScreen.activeSelf == false)
        {
            if (PauseScreen.activeSelf == true) return;
            //Events.PauseGame();
            Time.timeScale = 0;

            PlayerObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FPS_UI.SetActive(false);
            SkillScreen.SetActive(true);   
        }
        else if (Input.GetKeyDown(KeyCode.K) && SkillScreen.activeSelf == true)
        {
            //Events.UnPauseGame();
            Time.timeScale = 1.0f;
            PlayerObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            FPS_UI.SetActive(true);
            SkillScreen.SetActive(false);
        }

    }
    public void ContinueButtonPressed()
    {
        print("continue game");
        Events.UnPauseGame();
    }
    public void OnPause()
    {
        print("game paused");
        Time.timeScale = 0;

        PlayerObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FPS_UI.SetActive(false);
        SkillScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }
    public void OnUnPause()
    {
        print("resume game");
        Time.timeScale = 1.0f;
        PlayerObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FPS_UI.SetActive(true);
        PauseScreen.SetActive(false);
    }
    public void OnExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
