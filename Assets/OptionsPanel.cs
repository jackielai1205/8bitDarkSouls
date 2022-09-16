using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    public GameObject OptionsPanelObj;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Welcome to Pause menu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o")){
        OptionsPanelObj.SetActive(true);

        Debug.Log("You have clicked the o button!");}
    }
}
