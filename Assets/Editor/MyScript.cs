using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MarkTests
{
    // A Test behaves as an ordinary method
    
    [Test]
    public void TestHealthUpgradePass(){
        PlayerPrefs.SetInt("currency", 5);
        
        Player player = new Player();
        player.health = 100;
        player.UpgradeHealth();
        
        Assert.That(player.health, Is.EqualTo(125));
    }
    [Test]
    public void TestStaminaUpgradePass(){
        PlayerPrefs.SetInt("currency", 5);

        Player player = new Player();
        player.stamina = 100;
        player.UpgradeStamina();
        
        Assert.That(player.stamina, Is.EqualTo(125));
    }
    [Test]
    public void TestDamageUpgradePass(){
        PlayerPrefs.SetInt("currency", 5);

        Player player = new Player();
        player.damage = 50;
        player.UpgradeDamage();
        
        Assert.That(player.damage, Is.EqualTo(100));
    }
}
