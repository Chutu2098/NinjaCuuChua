﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 20;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && (col.CompareTag("Enemy") || col.CompareTag("Monster") || col.CompareTag("Boss")))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
