using UnityEngine;

public class Enemy_Check_Player : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1")&& !enemy._attack)
        {
         
            enemy._follow = true;

            /*enemy.Target = collision.GetComponent<Player>();
           enemy.stateMachine.ChangeState(EnemyStateEnum.Follow);*/
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy._follow = false;
        enemy.Target = null;
       
       /* enemy.Target = null;
        enemy.stateMachine.ChangeState(EnemyStateEnum.Idle);
       */
    }
 
}
