using UnityEngine;

public class Minimob : MonoBehaviour
{
    [Header("Boss ���� ������Ʈ��")]
    public Transform minimob;                   // Boss�� Transform
    public Rigidbody2D RbCompo;                 // Rigidbody2D ������Ʈ
    public Boss_Animator AniCompo;              // Boss�� �ִϸ��̼� ������Ʈ
    public Boss_StateFactory StateCompo;        // ���� ���� ������Ʈ
    public Boss_AttackSkill boss_Skill;         // ���� ��ų ������Ʈ
    public Boss_Detecting Detecting;            // Ž�� ������Ʈ
    public SpriteRenderer _sprite;              // ��������Ʈ ������
    public float distanceThreshold = 0.2f;      // ���� ���� �Ӱ谪
    public Point point;                         // ����Ʈ ��ü (������ ����)
    public bool CanAttack = true;               // ���� ���� ����

    [Header("��")]
    [SerializeField] private int startingHealth;
    public int damage;                          // Boss�� ���ݷ�

    [Header("State")]
    public BossState attackState;               // ���� ����
    [SerializeField] private BossState currentState; // ���� ����
    public BossState lastState;                 // ���� ����

    [Header("���� ����")]
    [SerializeField] bool MoreAttack;           // �߰� ���� ����

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
    }// Boss�� ü��
    private void Awake()
    {
        // �ʿ��� ������Ʈ���� ������
        RbCompo = GetComponent<Rigidbody2D>();
        AniCompo = GetComponentInChildren<Boss_Animator>();
        StateCompo = GetComponentInChildren<Boss_StateFactory>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        boss_Skill = GetComponentInChildren<Boss_AttackSkill>();
        Detecting = GetComponentInChildren<Boss_Detecting>();

        // �⺻������ ���� ���� ����
        attackState = StateCompo.Boss_GetState(Boss_StateType.Attack);

        // ���� ���¿� �´� �̺�Ʈ ����
        attackState.OnAttack1 += boss_Skill.Minimob_Skill1;
        attackState.OnAttack2 += boss_Skill.Minimob_Skill2;
        attackState.OnAttack3 += boss_Skill.Minimob_Skill3;
    }

    private void Start()
    {
        // ü�� �ʱ�ȭ �� ���� ��ȯ
        
        minimob = GetComponentInParent<Transform>();
        TransitionState(StateCompo.Boss_GetState(Boss_StateType.Idle));
    }

    // ���� ��ȯ �Լ�
    public void TransitionState(BossState InputState)
    {
        if (InputState == null)
            return;

        // �̹� ���� ���¿� �����ϸ� ��ȯ���� ����
        if (currentState == InputState)
            return;

        // ���� ���°� ������ ����
        if (currentState != null)
            currentState.Exit();

        // ���ο� ���� �ʱ�ȭ
        InputState.InitializeState(this);

        // ���� ���¿� ���� ���� ������Ʈ
        lastState = currentState;
        currentState = InputState;
        currentState.Enter();
    }

    private void Update()
    {
        // ���� ������ ������Ʈ ȣ��
        currentState.StateUpdate();

        // �׽�Ʈ��: DŰ�� ������ �� ü�� ����
        if (Input.GetKeyDown(KeyCode.D))
        {
            Health -= 1000;
        }

        // �׽�Ʈ��: Q, W Ű�� ���� ȣ��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackState.OnAttack1.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            attackState.OnAttack2.Invoke();
        }

        // Boss�� ������ Ÿ������ ��ȯ
        Flip();
    }

    private void FixedUpdate()
    {
     
        currentState.StateFixedUpdate();
    }

    // ���� ���� ���� �Լ�
    public void ChoseRandomAttack()
    {
        if (CanAttack)
        {
            CanAttack = false;

            // ���� ������ �����ϸ� �� ��° ���� ����
            if (Detecting.melee_Attack)
            {
                attackState.OnAttack2.Invoke();
            }
            else
            {
                // �߰� ������ �����ϸ� �������� ��ų�� ����
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
                    print("attack3����");
                    attackState.OnAttack1.Invoke();
                }
            }
        }
    }

    // Flip() �Լ�: Ÿ���� ���⿡ �°� Boss�� ��������Ʈ�� ������
    private void Flip()
    {
        if (Detecting.target != null)
        {
            // Ÿ���� ��ġ�� Boss�� ��ġ�� ���Ͽ� ������ ���
            Vector2 direction = (Detecting.target.transform.position - transform.position).normalized;
            Vector2 forward = transform.right;

            // Dot Product�� ����Ͽ� Ÿ���� �������� ���������� �Ǻ�
            float dotProduct = Vector2.Dot(forward, direction);

            // Ÿ���� �������̸� ��������Ʈ�� ������
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

    // ȸ�� �Լ� (������ ����)
    private void Rotattion(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        // Ÿ���� ���� ȸ��
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    // �浹 ó�� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            // health -= bullet.damage; // ���� ó�� �κ� 

            // ü���� 0 ������ ��� ���� ���·� ��ȯ
            if (Health <= 0)
            {
                TransitionState(StateCompo.Boss_GetState(Boss_StateType.Death));
                return;
            }

            // ��Ʈ ���·� ��ȯ
            TransitionState(StateCompo.Boss_GetState(Boss_StateType.Hit));
        }
    }
}
