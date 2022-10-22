using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingVoid : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == player.name){
            player.TakeDamage(1000);
        }
    }
}
