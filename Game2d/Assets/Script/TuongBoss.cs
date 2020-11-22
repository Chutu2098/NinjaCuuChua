using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuongBoss : MonoBehaviour
{
    Collider2D col;
    Rigidbody2D rb2d;

    public float timedelay = 2; // sau 2 s thì tường chắn mới rơi

    public BossController boss;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponentInChildren<BossController>();
        col = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.Die)
        {
            StartCoroutine(fall());// chạy hàm IEnumerator
        }
    }

    public IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay); //  chờ 2 giây đổi giá trị của tường
        rb2d.bodyType = RigidbodyType2D.Dynamic;    //  đổi rigibody từ static sang dynamic
        col.isTrigger = true;                       //  thêm colider thành trigger
        yield return 0;
    }
}
