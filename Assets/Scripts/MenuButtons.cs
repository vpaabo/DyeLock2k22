using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button StartButton;
    public Button OptionsButton;
    public Button ExitButton;

    private void Awake()
    {
        StartButton.onClick.AddListener(OnStart);
        ExitButton.onClick.AddListener(OnExit);
    }


    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnExit()
    {
        print("Exit button pressed");
        Application.Quit();
    }
}
