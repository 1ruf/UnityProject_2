using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public Transform AttackPoint;

    public StateFectory StateCompo { get; protected set; }
    public EntityState CurrentState { get; protected set; }
    public EntityState PreviousState { get; protected set; }
    public Rigidbody2D RbCompo { get; protected set; }
    public EntityAnimation AnimCompo { get; protected set; }

    public EnemyControl EnemyContol { get; private set; }

    [SerializeField] public EntityData Data;

    protected SpriteRenderer _spriteRenderer;
    public float _currentHp { get; private set; }
    public float _speed { get; private set; }
    public Vector2 MoveDire { get; private set; }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 6);
    }

    private void Awake()
    {
        _speed = Data.moveSpeed;
        _currentHp = Data.maxHp;
        StateCompo = GetComponentInChildren<StateFectory>();
        AnimCompo = GetComponent<EntityAnimation>();
        RbCompo = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        EnemyContol = GetComponent<EnemyControl>();

        StateCompo.InitializeState(this);
        MoveDire = Vector2.zero;
    }

    internal void SetMoveSpeed(float speed)
    {
        _speed = speed;
    }

    public void Start()
    {
        TransitionState(StateCompo.GetState(StateType.Idle));
    }

    private void Update()
    {
        if (_currentHp <= 0 && StateCompo.StateCheck(CurrentState))
            TransitionState(StateCompo.GetState(StateType.Death));
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
        if (moveDire == Vector2.zero || !StateCompo.StateCheck(CurrentState)) return;
        AnimCompo.SetMoveParameters(moveDire);
    }

    internal void SetHPUI()
    {
        Bar.Instance.BarValueChange(BarSliderType.Hp, _currentHp, Data.maxHp);
    }

    public void Attack()
        => TransitionState(StateCompo.GetState(StateType.Attack));


    public void TakeDamage(float damage)
    {
        _currentHp = Mathf.Clamp(_currentHp -= damage, 0, Data.maxHp);
        if (transform.tag == "Player") SetHPUI();
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
