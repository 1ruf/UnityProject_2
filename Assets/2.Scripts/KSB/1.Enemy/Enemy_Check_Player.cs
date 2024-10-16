using UnityEngine;

public class Enemy_Check_Player : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player1")&& !enemy._attack)
        {
         
            enemy._follow = true;
            Debug.Log("follow_Start");
            /*enemy.Target = collision.GetComponent<Player>();
           enemy.stateMachine.ChangeState(EnemyStateEnum.Follow);*/
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        enemy.Target = null;
        enemy._follow = false;
        Debug.Log("follow_End");
       /* enemy.Target = null;
        enemy.stateMachine.ChangeState(EnemyStateEnum.Idle);
       */
    }
}
