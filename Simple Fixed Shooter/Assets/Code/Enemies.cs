using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Animator animator;
    public float EnemySpeed = 5f;
    public GameObject EnemyPrefab;
    public float EnemyHealth = 1f;
    private AudioSource DeathPlayer;
    private bool facingRight;
    public bool Alive = true;
    public AudioClip DeathSound;
    private bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.rotation.y == 0)
        {
            facingRight = true;
        }
        DeathPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("Alive", Alive);
        Flip();
        MoveToMiddle();
        if (EnemyHealth <= 0)
        {
            if (played == false)
            {
                Invoke("PlayDeath", 0.1f);
                played = true;
            }
            Alive = false;
            Invoke("Destruct", 0.8f);
        }
    }

    void PlayDeath()
    {
        DeathPlayer.PlayOneShot(DeathSound, 0.1F);
    }

    private void Flip()
    {
        if ((transform.position.x >= 0 && facingRight) || (transform.position.x < 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void MoveToMiddle()
    {
        if (transform.position.x > 0)
        {
            transform.position -= new Vector3(Time.deltaTime * EnemySpeed, 0 ,0);
        }
        if (transform.position.x < 0)
        {
            transform.position += new Vector3(Time.deltaTime * EnemySpeed, 0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Subi(Clone)")
        {
            EnemyHealth -= 1;
        }
    }

    private void Destruct()
    {
        Destroy(gameObject);
        ScoreKeeper.ScorePoints(1);
    }
}
