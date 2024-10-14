using System;
using UnityEngine;

public class Enemy_Attack_Check_Player : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
  
    private void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player1") )
        {
     
            Debug.Log("Attack Start");
            enemy.Target = collision.GetComponent<Player>();
            enemy.stateMachine.ChangeState(EnemyStateEnum.Attack);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {

            Debug.Log("Attack End");
            enemy.Target = null;
            enemy.stateMachine.ChangeState(EnemyStateEnum.Idle);
        }
    }

}
