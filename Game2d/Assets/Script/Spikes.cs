using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            player.Damage(10);
            player.Knockback(50f, player.transform.position);
=======
            player.Damage(1);
            player.Knockback(100f, player.transform.position);
>>>>>>> Stashed changes
        }
    }
}
