using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip coins, swords, destroy,bullet,ua;

    public AudioSource adisrc;
    // Use this for initialization
    void Start()
    {
        coins = Resources.Load<AudioClip>("icons");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("crash");
        bullet = Resources.Load<AudioClip>("bullet");
        ua = Resources.Load<AudioClip>("ua");
        adisrc = GetComponent<AudioSource>();

    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "coins":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;

            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;

            case "sword":
                adisrc.clip = swords;
                adisrc.PlayOneShot(swords, 1f);
                break;
            case "bullet":
                adisrc.clip = bullet;
                adisrc.PlayOneShot(bullet, 1f);
                break;
            case "ua":
                adisrc.clip = ua;
                adisrc.PlayOneShot(ua, 1f);
                break;

        }
    }
}

