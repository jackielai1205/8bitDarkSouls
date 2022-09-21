using Script.Model.Enemy.EnemyType;

namespace Script.Model.Enemy.EnemyType
{
    public class Boss : GroundEnemy
    {
        public string bossName;
        public Skill[] skills;

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
