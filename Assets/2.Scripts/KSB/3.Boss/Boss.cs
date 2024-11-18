using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("컴포넌트들")]
    public Rigidbody2D RbCompo;
    public Boss_Animator AniCompo;
    public Boss_StateFactory StateCompo;
    public Boss_AttackSkill BossSkill;
    public Boss_Detecting Detecting;
    public SpriteRenderer _sprite;

    [Header("상태 관련 변수")]
    public float distanceThreshold = 0.2f;
    public Point point;
    public bool CanAttack = true;
    [SerializeField] private int startingHealth;

    public int Health
    {
        get
        {
            return startingHealth;
        }
        set
        {
            startingHealth = Mathf.Max(0, value);
        }
    }
    public int damage;

    [Header("State")]
    [SerializeField] private BossState attackState;
    [SerializeField] private BossState currentState;
    public BossState lastState;

    private void Awake()
    {
        // 컴포넌트 초기화
        RbCompo = GetComponent<Rigidbody2D>();
        AniCompo = GetComponentInChildren<Boss_Animator>();
        StateCompo = GetComponentInChildren<Boss_StateFactory>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        BossSkill = GetComponentInChildren<Boss_AttackSkill>();
        Detecting = GetComponentInChildren<Boss_Detecting>();

        // 공격 상태 초기화
        attackState = StateCompo.Boss_GetState(Boss_StateType.Attack);

        // 공격 이벤트 구독
        attackState.OnAttack1 += BossSkill.Boss_Skill1;
        attackState.OnAttack2 += BossSkill.Boss_Skill2;
        attackState.OnAttack3 += BossSkill.Boss_Skill3;
        attackState.OnAttack4 += BossSkill.Boss_Skill4;
    }

    private void Start()
    {
        // 초기 상태 전환
        TransitionState(StateCompo.Boss_GetState(Boss_StateType.Idle));
    }

    public void TransitionState(BossState inputState)
    {
        if (inputState == null || currentState == inputState) return;

        currentState?.Exit();
        inputState.InitializeState(this);

        lastState = currentState;
        currentState = inputState;
        currentState.Enter();
    }

    private void Update()
    {
        // 테스트
        if (Input.GetKeyDown(KeyCode.W)) attackState.OnAttack1.Invoke();
        if (Input.GetKeyDown(KeyCode.E)) attackState.OnAttack2.Invoke();
        if (Input.GetKeyDown(KeyCode.Q)) attackState.OnAttack3.Invoke();
        if (Input.GetKeyDown(KeyCode.R)) attackState.OnAttack4.Invoke();


        currentState.StateUpdate();

        // 공격 가능 시 Flip
        if (CanAttack) Flip();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }

    public float GetDelay()
    {
        return Random.Range(0.5f, 1.5f);
    }

    public void ChoseRandomAttack()
    {
        CanAttack = false;
        float randomValue = Detecting.melee_Attack ? Random.Range(0, 10) : Random.Range(0, 10);

        if (Detecting.melee_Attack)
        {
            if (randomValue < 7) attackState.OnAttack4.Invoke();
            else if (randomValue < 8) attackState.OnAttack3.Invoke();
            else if (randomValue < 9) attackState.OnAttack2.Invoke();
            else attackState.OnAttack1.Invoke();
        }
        else
        {
            if (randomValue < 4) attackState.OnAttack3.Invoke();
            else if (randomValue < 7) attackState.OnAttack2.Invoke();
            else attackState.OnAttack1.Invoke();
        }
    }

    private void Flip()
    {
        if (Detecting.target != null)
        {
            Vector2 direction = (Detecting.target.transform.position - transform.position).normalized;
            float dotProduct = Vector2.Dot(transform.right, direction);

            _sprite.flipX = dotProduct < 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            // health -= bullet.damage;

            if (Health <= 0)
            {
                TransitionState(StateCompo.Boss_GetState(Boss_StateType.Death));
                return;
            }

            TransitionState(StateCompo.Boss_GetState(Boss_StateType.Hit));
        }
    }
}
