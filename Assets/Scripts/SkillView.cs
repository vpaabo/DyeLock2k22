using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillView : MonoBehaviour
{
    public GameObject SkillScreen;
    
    public GameObject OtherUI;
    public GameObject PlayerObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && SkillScreen.activeSelf == false)
        {
            //Events.PauseGame();
            print("game paused");
            Time.timeScale = 0;

            PlayerObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            OtherUI.SetActive(false);
            SkillScreen.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.K) && SkillScreen.activeSelf == true)
        {
            //Events.UnPauseGame();
            print("game paused");
            Time.timeScale = 0;

            PlayerObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            OtherUI.SetActive(false);
            SkillScreen.SetActive(true);
        }
    }
}
