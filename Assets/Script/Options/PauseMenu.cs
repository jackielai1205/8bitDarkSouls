using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{
    // [SerializeField] GameObject pauseMenu;

    // public void Pause() 
    // {
    //     pauseMenu.SetActive(true);
    //     Time.timeScale = 0f;
    // }

    // public void Resume() 
    // {
    //     pauseMenu.SetActive(false);
    //     Time.timeScale = 1f;
    // }

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    
    public GameObject OptionsPanel;
    public Button ResumeButton;

    public Button OptionsButton333;

    void Update() 
    {
        //Cursor.visible = true;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                
            }
        }
        
        // Button btn = OptionsButton333.GetComponent<Button>();
        // btn.onClick.AddListener(TaskOnClick);

        
    }

    void Resume() 
    {
        Debug.Log("Clicked");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //OpenOptions();
        // Debug.Log("You have clicked the button!");
        // Button btn = OptionsButton333.GetComponent<Button>();
        // btn.enabled = true;
        
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("Pressed");
        //     Button resumeButton = ResumeButton.GetComponent<Button>();
        //     //resumeButton = GameObject.FindGameObjectWithTag("ResumeButton").GetComponent<Button>();
        //     resumeButton.onClick.AddListener(TaskOnClick);
        // }

        // void TaskOnClick()
        // {
        //     Resume();
        // }

    }

    // void OnApplicationPause() 
    // {
    //     Update();
    //     if (Input.GetKeyDown("o")){
    //     OptionsPanel.SetActive(true);

    //     Debug.Log("You have clicked the o button!");}
    // }

    // void OpenOptions() {
    //     if (Input.GetKeyDown("o"))
    //     {
    //         Debug.Log("You have clicked the o button!");
    //         //TaskOnClick();
    //     }
    // }

}
