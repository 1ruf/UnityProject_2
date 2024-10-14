using UnityEngine;

public class Enemy_Attack_Check_Player : MonoBehaviour
{
    private Enemy enemy = new Enemy();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.Target = collision.GetComponent<Player>();
            enemy.stateMachine.ChangeState(EnemyStateEnum.Attack);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.Target = null;
        enemy.stateMachine.ChangeState(EnemyStateEnum.Idle);
    }
}
