using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public Player mPlayer;
   

    // Start is called before the first frame update
    void Start()
    {
        
        if (mPlayer == null)
        {
            mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            mPlayer.Damage(10); // khi người chơi va chạm vào sẽ trừ máu đi 1
            mPlayer.Knockback(50f, mPlayer.transform.position);
        }
    }


}
