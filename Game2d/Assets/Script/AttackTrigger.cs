using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 20;

    private void OnTriggerEnter2D(Collider2D col)
    {
<<<<<<< Updated upstream

        if (col.isTrigger != true && (col.CompareTag("Enemy") || col.CompareTag("Monster") || col.CompareTag("Boss")))

=======
        if (col.isTrigger != true && col.CompareTag("Ground"))
>>>>>>> Stashed changes
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
