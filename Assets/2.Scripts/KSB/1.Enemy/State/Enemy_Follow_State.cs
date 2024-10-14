using UnityEngine;

public class Enemy_Follow_State : EnemyState
{
    [SerializeField] private Enemy_Check_Player _checker;// 귀찮으니 그냥 serializefield로 가져오고
    private Enemy enemy;
    private Rigidbody2D rd;
    GameObject target;
    Vector2 EnemyPos;
    private void Awake()
    {
        rd = enemy.GetComponent<Rigidbody2D>();
    }
    public Enemy_Follow_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {

    }
    private void Update()
    {
       EnemyPos = Enemy.Target.transform.position;
    }
    private void FixedUpdate()
    {
        Follow();
    }
    private void Follow()
    {
        Vector2 direction = (EnemyPos - (Vector2)transform.position).normalized;
        rd.AddForce(direction *Enemy.Espeed);
    }

  
}
