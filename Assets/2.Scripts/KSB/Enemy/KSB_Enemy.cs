using UnityEngine;

public class KSB_Enemy : MonoBehaviour
{
    public EnemySO _enemySO;
    public Sprite Visual_Sprite;
    [field: SerializeField] public InputReader InputCompo { get; private set; }
    public EnemyAnimation AnimationCompo { get; private set; }
    public Collider2D ColliderCompo { get; private set; }
    [SerializeField] private Transform IdlePositon;
    public bool shouldMove;
    public Rigidbody2D RbCompo { get; private set; }

    [SerializeField] private E_State currentState = null, previousState = null;
    public Collider2D target;
    public SpriteRenderer spriteRender;

    public float Hp;
    public Sensing _sensing;
    [Header("State debugging:")]
    public string stateName = "";
    public Vector3 point;

    public MoveState_SB MoveState;
    public AttackState_SB AttackState;
    public FollowState_SB FollowState;
    public IdleState_SB IdleState;
    public DeathState_SB DeathState;



    private void Awake()
    {
      
        MoveState = GetComponent<MoveState_SB>();
        AttackState = GetComponent<AttackState_SB>();
        FollowState = GetComponent<FollowState_SB>();
        IdleState = GetComponent<IdleState_SB>();

        Visual_Sprite = _enemySO.Visual;
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        ColliderCompo = GetComponent<Collider2D>();
        RbCompo = GetComponent<Rigidbody2D>();
        AnimationCompo = GetComponentInChildren<EnemyAnimation>();
        _sensing = GetComponentInChildren<Sensing>();

        E_State[] states = GetComponentsInChildren<E_State>();
        foreach (E_State state in states)
            state.InitializeState(this);
    }

    private void Start()
    {
        Hp = _enemySO.hp;
        TransitionState(IdleState);
        spriteRender.sprite = Visual_Sprite;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Hp -= 100;
        }
      

        currentState.StateUpdate();
        point = IdlePositon.position;
    }

    private void FixedUpdate()
    {
     
            currentState.StateFixedUpdate();
    }

    internal void TransitionState(E_State desireState)
    {
        if (desireState == null) return;

        if (currentState == desireState) return;
        else if (currentState != null)
            currentState.Exit();

        previousState = currentState;
        currentState = desireState;
        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }


}


