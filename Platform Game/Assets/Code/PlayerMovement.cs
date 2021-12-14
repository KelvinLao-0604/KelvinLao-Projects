using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed = 0.5f;
    public float JumpForce = 0.5f;
    public GameObject WinPrefab;
    public GameObject DeathPrefab;
    public LayerMask Ladderlayer;
    public AudioClip JumpSound;
    public AudioClip DeathSound;
    private AudioSource SoundPlayer;
    private bool facingRight = false;
    private float horizontalValue;
    private float verticalValue;
    private bool isClimbing = false;
    private Rigidbody2D Player_rigidbody;
    private bool disableMoving = false;
    private bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        Player_rigidbody = GetComponent<Rigidbody2D>();
        SoundPlayer = GetComponent<AudioSource>();
    }


    private void Move()
    {
        if (disableMoving == false)
        {
            float horizontaltransform = horizontalValue * Time.deltaTime * PlayerSpeed;
            transform.position += new Vector3(horizontaltransform, 0, 0);
        }    
    }

    private void Flip()
    {
        if ((horizontalValue > 0 && facingRight) || (horizontalValue < 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void ClimbLadder(RaycastHit2D hitInfo)
    {
        if (isClimbing == true && hitInfo.collider != null)
        {
            Player_rigidbody.velocity = new Vector2(0, verticalValue * PlayerSpeed);
            Player_rigidbody.gravityScale = 0;
        }
        else
        {
            Player_rigidbody.gravityScale = 1;
            disableMoving = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && Mathf.Abs(Player_rigidbody.velocity.y) < 0.01f)
        {
            Player_rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            SoundPlayer.PlayOneShot(JumpSound, 1F); 
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, PlayerSpeed, Ladderlayer);
        verticalValue = Input.GetAxis("Vertical");
        if (hitInfo.collider != null)
        {
            if (verticalValue != 0)
            {
                isClimbing = true;
                disableMoving = true;
            }
            else
            {
                if (Input.GetButtonDown("Jump") == true && horizontalValue != 0)
                {
                    isClimbing = false;
                    disableMoving = false;
                }
            }
        }
        ClimbLadder(hitInfo);
        Move();
        Flip();
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Reload();
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Lava")
        {
            SoundPlayer.PlayOneShot(DeathSound, 0.5F);
            GameObject camera = GameObject.Find("Main Camera");
            CameraFollower cameraMovement = camera.GetComponent<CameraFollower>();
            cameraMovement.won = true;
            Instantiate(DeathPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            disableMoving = true;
            transform.position = new Vector2(1000f, 100f);
            Invoke("Reload", 1.5f);
        }
        if (collision.collider.name == "Ending Platform" && won == false)
        {
            won = true;
            GameObject camera = GameObject.Find("Main Camera");
            CameraFollower cameraMovement = camera.GetComponent<CameraFollower>();
            cameraMovement.won = true;
            Instantiate(WinPrefab, new Vector2(13.60f, 0.022f), Quaternion.identity);
            PlayerMovement.Destroy(gameObject);
        }
        if (collision.collider.name == "King Slime")
        {
            SoundPlayer.PlayOneShot(DeathSound, 0.5F);
            GameObject camera = GameObject.Find("Main Camera");
            CameraFollower cameraMovement = camera.GetComponent<CameraFollower>();
            cameraMovement.won = true;
            Instantiate(DeathPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            disableMoving = true;
            transform.position = new Vector2(1000f, 100f);
            Invoke("Reload", 1.5f);
        }
    }

}
