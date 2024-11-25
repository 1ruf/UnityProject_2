using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public Transform AttackPoint;

    public StateFectory StateCompo { get; protected set; }
    public EntityState CurrentState { get; protected set; }
    public EntityState PreviousState { get; protected set; }
    public Rigidbody2D RbCompo { get; protected set; }
    public EntityAnimation AnimCompo { get; protected set; }

    public EnemyControl _enemycontol { get; private set; }

    protected SpriteRenderer _spriteRenderer;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _currentHp;
    public Vector2 MoveDire { get; private set; }

    private void Awake()
    {
        _currentHp = _maxHp;
        StateCompo = GetComponentInChildren<StateFectory>();
        AnimCompo = GetComponent<EntityAnimation>();
        RbCompo = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemycontol = GetComponent<EnemyControl>();

        StateCompo.InitializeState(this);
    }


    public void Start()
    {
        TransitionState(StateCompo.GetState(StateType.Idle));
    }

    private void OnEnable()
    {
        //SetMoveDire(Vector2.zero);
    }
    private void OnDisable()
    {
        SetMoveDire(Vector2.zero);
    }

    private void FixedUpdate()
    {
        CurrentState.StateFixedUpdate();
    }


    public void SetMoveDire(Vector2 moveDire)
    {
        MoveDire = moveDire;
        if (moveDire == Vector2.zero) return;
        AnimCompo.SetMoveParameters(moveDire);
    }

    public void Attack()
        => TransitionState(StateCompo.GetState(StateType.Attack));


    public void TakeDamage(float damage)
    {
        _currentHp = Mathf.Clamp(_currentHp -= damage, 0, _maxHp);
        if (_currentHp > 0)
            TransitionState(StateCompo.GetState(StateType.Hit));
        else
            TransitionState(StateCompo.GetState(StateType.Death));
    }

    public void TransitionState(EntityState desireState)
    {
        if (desireState == null) return;

        if (CurrentState != null)
        {
            CurrentState.Exit();
            PreviousState = CurrentState;
        }
        CurrentState = desireState;
        CurrentState.Enter();
    }
}
