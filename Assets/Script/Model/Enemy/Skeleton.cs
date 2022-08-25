
using UnityEngine;
using Random = System.Random;

public class Skeleton : Enemy
{

    public override void Attack()
    {
        Random random = new Random();
        int randomNumber = random.Next(2, 4);
        GetComponent<Animator>().SetInteger("AnimState", randomNumber);
    }

}
