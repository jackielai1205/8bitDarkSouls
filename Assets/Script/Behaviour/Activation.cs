using Script.Model.Enemy.EnemyType;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public Enemy enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.SetActivate(true);
            enemy.SetTarget(other.gameObject);
            // enemy.StartWalk();
        }
    }

    // void OnTriggerStay2D(Collider2D col)
    // {
    //     if (col.gameObject.CompareTag("Player") && !enemy.IsAttacking())
    //     {
    //         Debug.DrawLine(enemy.transform.position, col.transform.position, Color.green);
    //     }
    // }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.SetActivate(false);
            enemy.StartIdle();
        }
    }
}
