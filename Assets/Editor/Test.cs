
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

        [UnityTest]
        public IEnumerator BatAttackTest()
        {
            var bat = new GameObject().AddComponent<Bat>();
            var animator = bat.AddComponent<Animator>();
            var render = bat.AddComponent<SpriteRenderer>();
            animator.runtimeAnimatorController = Resources.Load("Assets/Animation/Bat/BatController.controller") as RuntimeAnimatorController;
            bat.Start();
            bat.StartChaseState();
            bat.transform.position = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(3);
            Assert.AreEqual(bat.transform, new Vector3(1,0,0));
        }
    }
}
