using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public float AtkDmg = 2f;

    public Vector3 atkOffset;
    public float atkRange = 0.5f; // khoảng cách tấn công
    public LayerMask atkMask;

    public Player player;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * atkOffset.x;
        pos += transform.up * atkOffset.y;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Collider2D colInfo = Physics2D.OverlapCircle(pos, atkRange, atkMask);

        if(colInfo != null && colInfo.CompareTag("Player"))
        {
            colInfo.SendMessageUpwards("Damage", AtkDmg);
        }
    }

}
