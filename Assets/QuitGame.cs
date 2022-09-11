using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
     public int MainMenuScene;

    public void ExitGame() {
        SceneManager.LoadScene(MainMenuScene);
    }
}
