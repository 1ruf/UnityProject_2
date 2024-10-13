using UnityEngine;

public class Enemy : MonoBehaviour
{

    [field: SerializeField] public Rigidbody2D rigid { get; set; }
    [field: SerializeField] public SpriteRenderer spriteRenderer { get; private set; }
    [field: SerializeField] public Animator animator { get; set; }
    [field: SerializeField] public EnemyStateMachine stateMachine { get; set; }

    [SerializeField] private string currentStateCheck;

    private bool dirRight = true;
    private int dir = 1;
    public bool rightDir = true;
    public Vector2 MoveInput { get; set; }
    private float yvaloxity;






    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigid = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        stateMachine = new EnemyStateMachine();

        stateMachine.AddState(EnemyStateEnum.Idle, new Enemy_Idle_State(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStateEnum.Attack, new Enemy_Attack_State(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStateEnum.Death, new Enemy_Death_State(this, stateMachine, "Death"));
        stateMachine.AddState(EnemyStateEnum.Follow, new Enemy_Follow_State(this, stateMachine, "follow"));

    }
    private void Start()
    {

        stateMachine.Initialize(EnemyStateEnum.Idle);

    }
    public void Update()
    {
        currentStateCheck = stateMachine.currentState.ToString();
        stateMachine.currentState.Update();

        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), yvaloxity);


    }


    public void EnemyFlip()
    {
        if (MoveInput.x > 0)
        {
            rightDir = false;


        }
        else if (MoveInput.x < 0)
        {
            rightDir = true;
        }

        spriteRenderer.flipX = rightDir;
    }



}
