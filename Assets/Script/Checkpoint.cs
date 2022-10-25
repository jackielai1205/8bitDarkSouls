using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject UpgradeMenu;
    public bool menuIsOpen = false;
    public Player player;
    public SaveLoad sv;
    public bool isCollidingPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == player.name){
            print("Game was saved on the checkpoint");
            sv.SaveCharacter();
            isCollidingPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == player.name){
            isCollidingPlayer = false;
            menuIsOpen = false;
            UpgradeMenu.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && isCollidingPlayer){
            if (menuIsOpen){
                menuIsOpen = false;
                UpgradeMenu.SetActive(false);
            } else if (Inventory.currencyCoins >= 5){
                menuIsOpen = true;
                UpgradeMenu.SetActive(true);
                }
            
        }
    }
}
