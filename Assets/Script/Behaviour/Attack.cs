using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("Entered");
        if (col.gameObject.CompareTag("Player"))
        {
            enemy.SetAttack(true);
            enemy.Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        enemy.StopAttack();
        enemy.SetAttack(false);
    }
}
