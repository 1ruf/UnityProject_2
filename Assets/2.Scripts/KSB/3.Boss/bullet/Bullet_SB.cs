using System.Collections;
using UnityEngine;

public class Bullet_SB : MonoBehaviour
{

    Rigidbody2D rigid;
    bool isShoot = false;
    Animator ani;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();


    }

    private void FixedUpdate()
    {
        
        rigid.AddForce(transform.up*0.25f, ForceMode2D.Impulse);
        if(!isShoot) 
        StartCoroutine(Destroys());



    }

    IEnumerator Destroys()
    {
        isShoot = true;
        transform.parent = null;
        yield return new WaitForSeconds(2f);
        ani.Play("Death");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1"))
        {
            ani.Play("Death");
            
        }
    }
}
