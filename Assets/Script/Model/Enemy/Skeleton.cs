
using UnityEngine;
using Random = System.Random;

public class Skeleton : MonoBehaviour
{

    private Animator _animator;
    public float movementSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWalk()
    {
        _animator.SetInteger("AnimState", 1);
    }

    public void StopWalk()
    {
        _animator.SetInteger("AnimState", 0);
    }
    
    public void Walk(Transform target)
    {
        if (transform.localPosition.x > target.transform.localPosition.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }else if (transform.localPosition.x < target.transform.localPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2 (transform.localScale.x, 0) * movementSpeed;
    }

    public void Attack()
    {
        Random random = new Random();
        int randomNumber = random.Next(2, 4);
        print(randomNumber);
        _animator.SetInteger("AnimState", randomNumber);
    }

    public void StopAttack()
    {
        _animator.SetInteger("AnimState", 0);
    }
}
