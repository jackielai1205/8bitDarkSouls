using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Build a number of scene to start when start button is pressed
    // Might have to change it to a global variable later
    public int gameStartScene;

    public void StartGame() {
        SceneManager.LoadScene(gameStartScene);
    }

    public void QuitGame() {
        Application.Quit();
    }   
}
