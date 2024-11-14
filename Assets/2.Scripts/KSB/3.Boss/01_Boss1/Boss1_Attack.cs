using UnityEngine;

public class Boss1_Attack : MonoBehaviour
{
    Boss _boss;
    private void Update()
    {
       
      
    }
    private void Awake()
    {
        _boss = GameObject.Find("Boss1").GetComponent<Boss>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            print("³Ë¹é");

            //player.hp -= _boss.damage;
            //³Ë¹é
        }
    }
}
