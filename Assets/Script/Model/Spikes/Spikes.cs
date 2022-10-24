using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            Player p = other.gameObject.GetComponent<Player>();
            p.TakeDamage(2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
