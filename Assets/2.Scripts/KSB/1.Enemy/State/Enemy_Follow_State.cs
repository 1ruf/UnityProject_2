using UnityEngine;

public class Enemy_Follow_State : EnemyState
{
    [SerializeField] private Enemy_Check_Player _checker;// 귀찮으니 그냥 serializefield로 가져오고
   
    private Rigidbody2D rd;
    Vector2 EnemyPos;
    public override void Enter()
    {
        Debug.Log("Start Follow");
    }
    private void Awake()
    {
        rd = Enemy.GetComponent<Rigidbody2D>();
    }
    public Enemy_Follow_State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolHash) : base(enemy, stateMachine, animBoolHash)
    {

    }
    public override  void Update()
    {
       //EnemyPos = Enemy.Target.transform.position;
    }
    private void FixedUpdate()
    {
        Follow();
    }
    private void Follow()
    {
        Vector2 direction = (EnemyPos - (Vector2)Enemy.transform.position).normalized;
        rd.AddForce(direction *Enemy.Espeed);
    }

    public override void Exit()
    {
        Debug.Log("follow_End");
    }

}
