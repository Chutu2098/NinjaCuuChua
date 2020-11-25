using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Player player;
    public int MonsterHealth = 100;

    public float distance; // khoảng cách giữa người chơi và trụ
    public float wakerange; // khoảng cách trụ bắt đầu hoạt động

    public bool awake = false;
    public bool faceRight = false;
    public bool Die = false;
    public bool IDE = true;

    public Animator anim;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = gameObject.GetComponent<Animator>();

    }

    private void Update()
    {
        anim.SetBool("awake", awake);

        RangeCheck();

        anim.SetBool("dead", Die); // tham chiếu giá trị die

        if (MonsterHealth <= 0)
        {
            Die = true; // set giá trị biến die
        }
    }

    void RangeCheck()
    {
        // tính khoảng cách giữ trụ đến người chơi
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < wakerange)
        {
            awake = true;
        }
        if (distance > wakerange)
        {
            awake = false;
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1;

        if (transform.position.x > player.transform.position.x && faceRight)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            faceRight = false;
        }
        else if (transform.position.x < player.transform.position.x && !faceRight)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            faceRight = true;
        }
    }

    public void Damage(int dmg)
    {
        MonsterHealth -= dmg;
    }

    public void Dead()
    {
        anim.SetBool("dead", Die);
    }

    public void DetroyMonster()
    {
        Destroy(gameObject);

    }

}
