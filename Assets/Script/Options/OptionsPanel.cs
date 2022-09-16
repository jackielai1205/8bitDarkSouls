using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    public GameObject OptionsPanelObj;
    public static bool OptionsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Pause menu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o"))
        {
            if(!OptionsOn)
            {
                OptionsPanelObj.SetActive(true);
                OptionsOn = true;
            }
            else 
            {
                OptionsPanelObj.SetActive(false);
                OptionsOn = false;
            }
        }

        // Quitting won't work in Play mode:
        if(Input.GetKeyDown("q"))
        {
            Debug.Log("Good bye!");
            Application.Quit(); // Check with build, also could use QuitGame.cs
        }
    }
}
