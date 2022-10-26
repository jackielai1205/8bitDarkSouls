using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public int MainMenuScene;
    public GameObject WinUI;
    public Player player;
    void Update() 
    {
        // if(Input.GetKeyDown("k"))
        // {
        //     Time.timeScale = 0f;
        //     player.winTime += 1;
        //     WinUI.SetActive(true);
        //     Debug.Log(player.winTime);
        // }
    }
    
    public void backToMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }
    
}
