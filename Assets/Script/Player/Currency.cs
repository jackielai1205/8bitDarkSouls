using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Player
{
    public class Currency : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D target)
        {
            if(target.gameObject.CompareTag("Player"))
            {
                Inventory.currencyCoins += 1;
                Destroy(gameObject);
            }
        }
    }
}

