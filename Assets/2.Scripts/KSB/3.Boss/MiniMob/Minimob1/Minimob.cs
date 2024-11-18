using UnityEngine;

public class Minimob : MonoBehaviour
{
    [Header("Boss 관련 컴포넌트들")]
    public Transform minimob;                   // Boss의 Transform
    public Rigidbody2D RbCompo;                 // Rigidbody2D 컴포넌트
    public Boss_Animator AniCompo;              // Boss의 애니메이션 컴포넌트
    public Boss_StateFactory StateCompo;        // 상태 관리 컴포넌트
    public Boss_AttackSkill boss_Skill;         // 공격 스킬 컴포넌트
    public Boss_Detecting Detecting;            // 탐지 컴포넌트
    public SpriteRenderer _sprite;              // 스프라이트 렌더러
    public float distanceThreshold = 0.2f;      // 공격 범위 임계값
    public Point point;                         // 포인트 객체 (사용되지 않음)
    public bool CanAttack = true;               // 공격 가능 여부

    [Header("잡")]
    [SerializeField] private int startingHealth;
    public int damage;                          // Boss의 공격력

    [Header("State")]
    public BossState attackState;               // 공격 상태
    [SerializeField] private BossState currentState; // 현재 상태
    public BossState lastState;                 // 이전 상태

    [Header("공격 여부")]
    [SerializeField] bool MoreAttack;           // 추가 공격 여부

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
    }// Boss의 체력
    private void Awake()
    {
        // 필요한 컴포넌트들을 가져옴
        RbCompo = GetComponent<Rigidbody2D>();
        AniCompo = GetComponentInChildren<Boss_Animator>();
        StateCompo = GetComponentInChildren<Boss_StateFactory>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        boss_Skill = GetComponentInChildren<Boss_AttackSkill>();
        Detecting = GetComponentInChildren<Boss_Detecting>();

        // 기본적으로 공격 상태 설정
        attackState = StateCompo.Boss_GetState(Boss_StateType.Attack);

        // 공격 상태에 맞는 이벤트 연결
        attackState.OnAttack1 += boss_Skill.Minimob_Skill1;
        attackState.OnAttack2 += boss_Skill.Minimob_Skill2;
        attackState.OnAttack3 += boss_Skill.Minimob_Skill3;
    }

    private void Start()
    {
        // 체력 초기화 및 상태 전환
        
        minimob = GetComponentInParent<Transform>();
        TransitionState(StateCompo.Boss_GetState(Boss_StateType.Idle));
    }

    // 상태 전환 함수
    public void TransitionState(BossState InputState)
    {
        if (InputState == null)
            return;

        // 이미 현재 상태와 동일하면 전환하지 않음
        if (currentState == InputState)
            return;

        // 현재 상태가 있으면 종료
        if (currentState != null)
            currentState.Exit();

        // 새로운 상태 초기화
        InputState.InitializeState(this);

        // 이전 상태와 현재 상태 업데이트
        lastState = currentState;
        currentState = InputState;
        currentState.Enter();
    }

    private void Update()
    {
        // 현재 상태의 업데이트 호출
        currentState.StateUpdate();

        // 테스트용: D키를 눌렀을 때 체력 감소
        if (Input.GetKeyDown(KeyCode.D))
        {
            Health -= 1000;
        }

        // 테스트용: Q, W 키로 공격 호출
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackState.OnAttack1.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            attackState.OnAttack2.Invoke();
        }

        // Boss의 방향을 타겟으로 전환
        Flip();
    }

    private void FixedUpdate()
    {
     
        currentState.StateFixedUpdate();
    }

    // 랜덤 공격 선택 함수
    public void ChoseRandomAttack()
    {
        if (CanAttack)
        {
            CanAttack = false;

            // 근접 공격이 가능하면 두 번째 공격 실행
            if (Detecting.melee_Attack)
            {
                attackState.OnAttack2.Invoke();
            }
            else
            {
                // 추가 공격이 가능하면 랜덤으로 스킬을 선택
                if (MoreAttack)
                {
                    int ran = Random.Range(0, 10);
                    if (ran < 6)
                    {
                        attackState.OnAttack1.Invoke();
                    }
                    else
                    {
                        attackState.OnAttack3.Invoke();
                    }
                }
                else
                {
                    print("attack3없음");
                    attackState.OnAttack1.Invoke();
                }
            }
        }
    }

    // Flip() 함수: 타겟의 방향에 맞게 Boss의 스프라이트를 뒤집음
    private void Flip()
    {
        if (Detecting.target != null)
        {
            // 타겟의 위치와 Boss의 위치를 비교하여 방향을 계산
            Vector2 direction = (Detecting.target.transform.position - transform.position).normalized;
            Vector2 forward = transform.right;

            // Dot Product를 사용하여 타겟이 왼쪽인지 오른쪽인지 판별
            float dotProduct = Vector2.Dot(forward, direction);

            // 타겟이 오른쪽이면 스프라이트를 뒤집음
            if (dotProduct < 0)
            {
                _sprite.flipX = false;
            }
            else
            {
                _sprite.flipX = true;
            }
        }
    }

    // 회전 함수 (사용되지 않음)
    private void Rotattion(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        // 타겟을 향해 회전
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    // 충돌 처리 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            // health -= bullet.damage; // 피해 처리 부분 

            // 체력이 0 이하일 경우 죽음 상태로 전환
            if (Health <= 0)
            {
                TransitionState(StateCompo.Boss_GetState(Boss_StateType.Death));
                return;
            }

            // 히트 상태로 전환
            TransitionState(StateCompo.Boss_GetState(Boss_StateType.Hit));
        }
    }
}
