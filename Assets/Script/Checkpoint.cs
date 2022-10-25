using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Interactable
{
    public Player player;
    public SaveLoad sv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact()
    {
        print("Game was saved on the checkpoint");
        sv.SaveCharacter();
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //
    //     if (other.gameObject.name == player.name){
    //         // print("Game was saved on the checkpoint");
    //         // sv.SaveCharacter();
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}