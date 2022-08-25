using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = .1f;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey ("right")) {
            transform.localScale = new Vector3 (1, 1, 1);
            rigidbody.AddForce(new Vector2(speed, 0));
        } else if (Input.GetKey ("left")) {
            transform.localScale = new Vector3 (-1, 1, 1);
            rigidbody.AddForce(new Vector2(-speed, 0));
        }
    }
}
