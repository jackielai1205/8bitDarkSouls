using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public enum Status
    {
        Health,
        Stamina,
        Rejuvenate,
        Attack
    }

    public Player player;
    public Status potionType;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("potion destroyed");

            switch(potionType)
            {
                case Status.Health:
                    Inventory.healthPotions += 1;
                    break;
                case Status.Stamina:
                    Inventory.staminaPotions += 1;
                    break;
                case Status.Rejuvenate:
                    Inventory.rejuvenationPotions += 1;
                    break;
                case Status.Attack:
                    Inventory.powerPotions += 1;
                    break;
            }
        }
    }
}
