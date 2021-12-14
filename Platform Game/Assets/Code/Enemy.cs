using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed = 0.05f;
    private bool facingLeft = true;
    void Start()
    {
        
    }

    private void Move()
    {
        if (facingLeft == true)
        {
            transform.position += new Vector3(Time.deltaTime * EnemySpeed, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(Time.deltaTime * EnemySpeed, 0, 0);
        }
    }

    private void facing()
    {
        if (transform.position.x >= 10.1f && facingLeft || transform.position.x <= 9.7f && !facingLeft)
        {
            facingLeft = !facingLeft;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        facing();
        Move();
    }
}
