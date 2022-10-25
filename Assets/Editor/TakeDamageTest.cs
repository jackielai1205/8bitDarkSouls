using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class TakeDamageTest
{

    [Test]
    public void TakeDamage_Test()
    {
        Player player = new Player();

        int damage = 10;
        player.currentHealth = 10;
        player.m_blocking = false;
        player.TakeDamage(damage);
        
        Assert.That(player.m_dead, Is.EqualTo(true));
    }
    
}
