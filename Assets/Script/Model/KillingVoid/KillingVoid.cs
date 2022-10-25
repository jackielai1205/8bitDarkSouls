using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingVoid : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            other.GetComponent<Player>().TakeDamage(1000);
        }
    }
}
