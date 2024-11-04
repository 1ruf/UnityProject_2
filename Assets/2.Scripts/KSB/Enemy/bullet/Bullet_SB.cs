using System.Collections;
using UnityEngine;

public class Bullet_SB : MonoBehaviour
{

    Rigidbody2D rigid;
    bool isShoot = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();



    }

    private void FixedUpdate()
    {
        
        rigid.AddForce(transform.right*2, ForceMode2D.Impulse);
        if(!isShoot) 
        StartCoroutine(Destroys());



    }

    IEnumerator Destroys()
    {
        isShoot = true;
        transform.parent = null;
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1"))
        {
            Destroy(gameObject);
        }
    }
}
