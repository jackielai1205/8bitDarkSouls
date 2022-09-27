using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Script.Model.Enemy;
using Script.Model.Enemy.EnemyType;
using Script.Model.Projectile;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;


namespace Editor
{
    public class Test
    {
        // [UnityTest]
        // public IEnumerable EnemyStopHitTest()
        // {
        //     var skeleton = AssetDatabase.LoadAssetAtPath<SwordSkeleton>("Assets/Prefabs/EnemyPrefabs/SwordSkeleton.prefab");
        //     skeleton.Start();
        //     skeleton.movementSpeed = 1;
        //     var targetObj = new GameObject();
        //     skeleton.SetTarget(targetObj);
        //     skeleton.WalkToCharacter();
        //     yield return new WaitForSeconds(skeleton.transform.position);
        //     Assert.AreEqual(new Vector3(1, 0 ,0 ), skeleton.transform.position);
        // }

        [Test]
        public void TakeDamageTest()
        {
            var skeleton = AssetDatabase.LoadAssetAtPath<SwordSkeleton>("Assets/Prefabs/EnemyPrefabs/SwordSkeleton.prefab");
            skeleton.Start();
            skeleton.health = 100;
            int damage = 10;
            skeleton.TakeDamage(damage);
            skeleton.HitState();
            Assert.AreEqual(90,skeleton.health);
        }

        [Test]
        public void DeadTest()
        {
            var skeleton = AssetDatabase.LoadAssetAtPath<SwordSkeleton>("Assets/Prefabs/EnemyPrefabs/SwordSkeleton.prefab");
            skeleton.Start();
            skeleton.health = 10;
            int damage = 10;
            skeleton.TakeDamage(damage);
            skeleton.HitState();
            Assert.IsTrue(skeleton);
        }

        [Test]
        public void BatAttackTest()
        {
            var bat = new GameObject().AddComponent<Bat>();
            var animator = bat.AddComponent<Animator>();
            var render = bat.AddComponent<SpriteRenderer>();
            animator.runtimeAnimatorController = Resources.Load("Assets/Animation/Bat/BatController.controller") as RuntimeAnimatorController;
            bat.Start();
            bat.StartChaseState();
            animator.SetInteger("AnimState", 1);
            Assert.AreEqual(1 , animator.GetInteger("AnimState"));
        }
    }
}
