using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;

    public Animator anim;
    public SoundManager sound;
    
    public Collider2D trigger;

   

    private void Awake()
    {
        
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();

    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !attacking)
        {
            sound.Playsound("sword");
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.3f;
           
        }

        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }

        anim.SetBool("Attacking", attacking);
    }
}