using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Model.Enemy.EnemyType
{
    public class Wizard : Boss
    {
        public EnemyHealthBar healthBar;
        public CanvasGroup winUI;
        public int MainMenuScene;

        //Add jump state for ground enemy
        public override void Update()
        {
            switch (GetAnimator().GetInteger(GetAnimState()))
            {
                case (int)State.Idle:
                    IdleState();
                    break;
                case (int)State.Chase:
                    healthBar.gameObject.SetActive(true);
                    PlayBossTheme();
                    ChaseCharacterState();
                    Cast();
                    break;
                case (int)State.Attack:
                    AttackState();
                    Cast();
                    break;
                case (int)State.Hit:
                    HitState();
                    break;
                case (int)State.Dead:
                    DeadState();
                    healthBar.gameObject.SetActive(false);
                    break;
            }
            if (this.health <= 0)
            {
                showWinUI();
            }
        }

        public override void StartAttack()
        {
            GetAnimator().SetInteger(GetAttackMethod(), 0);
            GetAnimator().SetInteger(GetAnimState(), 2);
        }

        public void Cast()
        {
            foreach (Skill.Skill skill in skills)
            {
                skill.Perform(weapon, GetTarget().transform, source);
            }
        }
        
        public override void DeadState()
        {
            // GetRigidbody2D().gravityScale = 1;
            // GetCollider2D().enabled = true;
        }

        public void showWinUI()
        {
            if (winUI.alpha <= 1)
            {
                winUI.alpha += Time.deltaTime;
            }
            StartCoroutine(backtoMainMenu());
        }

        IEnumerator backtoMainMenu()
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(MainMenuScene);
        }
        
    }
}