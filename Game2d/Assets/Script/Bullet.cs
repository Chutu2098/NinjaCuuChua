using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;
    private void Update()
    {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.isTrigger !=true && hitInfo.CompareTag("Ground") || hitInfo.CompareTag("Enemy"))
        {
			hitInfo.SendMessageUpwards("Damage", damage);

        }
		Destroy(gameObject);
	}
}
