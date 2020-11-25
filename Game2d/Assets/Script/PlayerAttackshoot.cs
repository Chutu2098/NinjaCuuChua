using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackshoot : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attackingshoot = false;

    public Animator anim;
    public Transform FirePoint;
    public GameObject Bullet;
    public SoundManager sound;
    public Collider2D trigger;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        FirePoint = transform.Find("FirePoint");
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !attackingshoot)
        {
            sound.Playsound("bullet");
            attackingshoot = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        }

        if (attackingshoot)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;

            }
            else
            {
                attackingshoot = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attackshoot", attackingshoot);
    }
}