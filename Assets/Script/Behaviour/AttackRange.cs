using System;
using System.Collections;
using System.Collections.Generic;
using Script.Model.Enemy;
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

    private void OnTriggerStay2D(Collider2D col)
    {
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
