using UnityEngine;

public class Boss : MonoBehaviour
{
    public Rigidbody2D RbCompo;
    public Boss_Animator AniCompo;
    public Boss_StateFactory StateCompo;
    public Boss_AttackSkill boss_Skill;
    public Boss_Detecting Detecting;
    public SpriteRenderer _sprite;
    public float distanceThreshold = 0.2f;
    public Point point;
    public bool CanAttack = true;


    [SerializeField] private int _Health = 300;
    public int health;
    public int damage;

    [SerializeField] private BossState attackState;


    private float _attackDelay;


    [SerializeField] private BossState currentState;
    public BossState lastState;

    private void Awake()
    {


        RbCompo = GetComponent<Rigidbody2D>();
        AniCompo = GetComponentInChildren<Boss_Animator>();
        StateCompo = GetComponentInChildren<Boss_StateFactory>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        boss_Skill = GetComponent<Boss_AttackSkill>();
        Detecting = GetComponentInChildren<Boss_Detecting>();
        attackState = StateCompo.Boss_GetState(Boss_StateType.Attack);

        attackState.OnAttack1 += boss_Skill.Skill1;
        attackState.OnAttack2 += boss_Skill.Skill2;
        attackState.OnAttack3 += boss_Skill.Skill3;
        attackState.OnAttack4 += boss_Skill.Skill4;
    }

    private void Start()
    {
        health = _Health;
        TransitionState(StateCompo.Boss_GetState(Boss_StateType.Idle));

    }

    public void TransitionState(BossState InputState)
    {
        if (InputState == null)
            return;

        if (currentState == InputState)
            return;
        if (currentState != null)
            currentState.Exit();

        InputState.InitializeState(this);

        lastState = currentState;
        currentState = InputState;
        currentState.Enter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("s");
            attackState.OnAttack1.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            attackState.OnAttack2.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackState.OnAttack3.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            print("work");
            attackState.OnAttack4.Invoke();
        }

        currentState.StateUpdate();
        if(CanAttack)
        Flip();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }
    public float GetDelay()
    {
        float delay = Random.Range(0.5f, 1.5f);
        return delay;
    }

    public void ChoseRandomAttack()
    {
        CanAttack = false;
        Vector3 targetPos = Detecting.target.transform.position;
        float randomValue;

        if (Detecting.melee_Attack)
        {
       
            randomValue = Random.Range(0, 10);
            if (randomValue < 7) 
            {
                attackState.OnAttack4.Invoke();
            }
            else if (randomValue < 8) 
            {
                attackState.OnAttack3.Invoke();
            }
            else if (randomValue < 9) 
            {
                attackState.OnAttack2.Invoke();
            }
            else 
            {
                attackState.OnAttack1.Invoke();
            }
        }
        else
        {
            randomValue = Random.Range(0, 10);
            if (randomValue < 4) 
            {
                attackState.OnAttack3.Invoke();
            }
            else if (randomValue < 7) 
            {
                attackState.OnAttack2.Invoke();
            }
            else 
            {
                attackState.OnAttack1.Invoke();
            }
        }
    }




    private void Flip()
    {
        if (Detecting.target != null)
        {
            Vector2 direction = (Detecting.target.transform.position - transform.position).normalized;
            Vector2 forward = transform.right;

            float dotProduct = Vector2.Dot(forward, direction);

            if (dotProduct < 0)
            {
                _sprite.flipX = true;


            }
            else
            {
                _sprite.flipX = false;

            }
        }
    }
    private void Rotattion(GameObject target)//target
    {
        if (target == null)
        {
            return;
        }

        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            //health -= bullet.damage;
            if (health <= 0)
            {
                TransitionState(StateCompo.Boss_GetState(Boss_StateType.Death));
                return;
            }
            TransitionState(StateCompo.Boss_GetState(Boss_StateType.Hit));


        }
    }


}
