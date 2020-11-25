using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxspeed = 5, maxjump = 4, jumpPow = 220f;
    public bool grounded = true, faceright = true, doublejump = false;

    public int ourHealth;
    public int maxhealth = 50;

    public Rigidbody2D r2;
    public Animator anim;
    public GameControl gmcol;
    public HeartUI hpUI;
    public gamemaster gm;
    public SoundManager sound;
    

    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxhealth;
        gmcol = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<gamemaster>();
        sound= GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        // if (hpUI == null)
        //{
        //  hpUI = gameObject.GetComponent<HeartUI>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.8f);
                }
            }

        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (r2.velocity.y > maxjump)
            r2.velocity = new Vector2(r2.velocity.x, maxjump);
        if (r2.velocity.y < -maxjump)
            r2.velocity = new Vector2(r2.velocity.x, -maxjump);

        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.8f, r2.velocity.y);
        }
        if (ourHealth <= 0)
        {
            Death();
        }
    }

    public void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0f);
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Damage(int damage)
    {
        ourHealth -= damage;
        gameObject.GetComponent<Animation>().Play("redflast");
    }

    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        if (faceright)
        {
            r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
        }
        else
        {
            r2.AddForce(new Vector2(Knockdir.x * 100, Knockdir.y * Knockpow));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gold"))
        {
            sound.Playsound("coins");
            Destroy(other.gameObject);
            gmcol.GamePoint++;
        }
        if (other.CompareTag("ngoc"))
        {
            sound.Playsound("coins");
            Destroy(other.gameObject);
            gm.highscore++;
        }
        //gmcol.GetPoint(); // dùng tạm thời . vẽ  tiền full map trước rồi sửa
        if (other.CompareTag("Thuoc"))
        {
            sound.Playsound("coins");
            Destroy(other.gameObject);
            if (ourHealth != maxhealth)
            {
                ourHealth += 10;
            }
        }
    }
}