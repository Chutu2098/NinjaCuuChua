using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX1 : MonoBehaviour
{
    public int Health = 100;
    public SoundManager sound;
    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
    }    

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            sound.Playsound("destroy");
            Destroy(gameObject);
        }
    }

    void Damage(int damage)
    {
        Health -= damage;
    }
}