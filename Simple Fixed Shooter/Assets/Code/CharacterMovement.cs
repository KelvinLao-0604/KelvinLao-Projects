using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public GameObject StarPrefab;
    private bool facingRight = false;
    public float PlayerSpeed = 5.0f;
    private float horizontalValue;
    private bool Firing = false;
    public float StarSpeed = 10.0f;
    public float StarSpawnSpeed = 0.5f;
    public GameObject DeathPrefab;
    public GameObject GameOverPrefab;
    public bool won = false;
    private void Start()
    {
        InvokeRepeating("Spawn", 0, StarSpawnSpeed);
    }

    private void Move()
    {
        float horizontaltransform = horizontalValue * Time.deltaTime * PlayerSpeed;
        transform.position += new Vector3(horizontaltransform,0,0);
    }

    private void Flip()
    {
        if ((horizontalValue > 0 && facingRight) || (horizontalValue < 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
    private void Update()
    {
        animator.SetBool("Firing", Firing);
        horizontalValue = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontalValue);
        Move();
        Flip();
        if (won == true)
        {
            CharacterMovement.Destroy(gameObject);
        }
    }

    private void Spawn()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            Firing = true;
            GameObject star = Instantiate(StarPrefab, transform.position + transform.right, Quaternion.identity);
            star.GetComponent<Rigidbody2D>().velocity = StarSpeed * transform.right;
        }
        else
        {
            Firing = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemies>() != null)
        {
            Instantiate(DeathPrefab, transform.position, Quaternion.identity);
            Instantiate(GameOverPrefab, new Vector3(0,0,0), Quaternion.identity);
            CharacterMovement.Destroy(gameObject);
        }
    }
}
