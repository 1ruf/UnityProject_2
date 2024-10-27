using UnityEngine;

public class KSB_Enemy : MonoBehaviour
{
    [field: SerializeField] EnemySO _enemySO;
    private  Sprite Visual_Sprite;
    [field: SerializeField] public InputReader InputCompo { get; private set; }
    public EnemyAnimation AnimationCompo { get; private set; }
    public Collider2D ColliderCompo { get; private set; }
    [SerializeField] private Transform IdlePositon;
    public bool shouldMove;
    public Rigidbody2D RbCompo { get; private set; }

    [SerializeField] private E_State currentState = null, previousState = null;
    public Collider2D target;
    public SpriteRenderer spriteRender;


    public Sensing _sensing;
    [Header("State debugging:")]
    public string stateName = "";
    public Vector3 point;

    private void Awake()
    { 
        _enemySO = GetComponent<EnemySO>();
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
       // TransitionState(_enemySO.IdleState);
        spriteRender.sprite = Visual_Sprite;

    }

    private void Update()
    {
       
        currentState.StateUpdate();
        point = IdlePositon.position;


        if (_sensing.Attack && _sensing.Detected)
        {
           // TransitionState(_enemySO.AttackState);
        }
        else if (_sensing.Detected && !_sensing.Attack|| _sensing.Detected)
        {
            //TransitionState(_enemySO.FollowState);
        }
        else if (shouldMove)
        {
           //TransitionState(_enemySO.MoveState);
        }
        else if (!_sensing.Detected && !_sensing.Attack)
        {
            //TransitionState(_enemySO.MoveState);
        }
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


