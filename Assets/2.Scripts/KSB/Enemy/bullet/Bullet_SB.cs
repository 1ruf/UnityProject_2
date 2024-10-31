using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_SB : MonoBehaviour
{

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
      

    }

    private void FixedUpdate()
    {
        rigid.MovePosition(transform.position + transform.right *15 * Time.fixedDeltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision != null)
        {
            Destroy(gameObject);
        }
    }
}
