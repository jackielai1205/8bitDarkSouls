
using System.Collections;
using NUnit.Framework;
using Script.Model.Enemy;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;


namespace Editor
{
    public class Test
    {

        [Test]
        public void TakeDamageTest()
        {
            var skeleton = AssetDatabase.LoadAssetAtPath<SwordSkeleton>("Assets/Prefabs/EnemyPrefabs/SwordSkeleton.prefab");
            skeleton.health = 100;
            skeleton.Start();
            int damage = 10;
            skeleton.TakeDamage(damage);
            skeleton.HitState();
            Assert.AreEqual(90,skeleton.health);
        }

        [Test]
        public void DeadTest()
        {
            var skeleton = AssetDatabase.LoadAssetAtPath<ShieldSkeleton>("Assets/Prefabs/EnemyPrefabs/ShieldSkeleton.prefab");
            skeleton.health = 10;
            skeleton.SetIsDead(false);
            skeleton.Start();
            int damage = 10;
            skeleton.TakeDamage(damage);
            skeleton.HitState();
            Assert.IsTrue(skeleton.GetIsDead());
        }

        [Test]
        public void BatTakeDamageTest()
        {
            var bat = AssetDatabase.LoadAssetAtPath<Bat>("Assets/Prefabs/EnemyPrefabs/Bat.prefab");
            bat.health = 30;
            bat.Start();
            int damage = 10;
            bat.TakeDamage(damage);
            bat.HitState();
            Assert.AreEqual(20,bat.health);
        }
    }
}
