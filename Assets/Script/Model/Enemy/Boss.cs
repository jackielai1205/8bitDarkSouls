using Script.Model.Enemy.EnemyType;

namespace Script.Model.Enemy
{
    public class Boss : GroundEnemy
    {
        public string bossName;
        public Skill[] skills;
    
        // // Start is called before the first frame update
        // void Start()
        // {
        //
        // }
        //
        // // Update is called once per frame
        // void Perform()
        // {
        //
        // }

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
}
