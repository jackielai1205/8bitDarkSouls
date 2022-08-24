using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int stamina;
    public Inventory inventory;

    void Dodge()
    {
        //write code here
    }

    void BlockIdle()
    {
        //write code here
    }

    void Block()
    {
        //write code here
    }

    void Interaction()
    {
        //write code here
    }

    void Jump()
    {
        //write code here
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Walk()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Hurt()
    {
        throw new System.NotImplementedException();
    }
}
