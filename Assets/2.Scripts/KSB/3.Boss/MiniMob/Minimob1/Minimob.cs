using UnityEngine;

public class Minimob : MonoBehaviour
{
    public Transform minimob;
    public Rigidbody2D RbCompo;
    public Boss_Animator AniCompo;
    public Boss_StateFactory StateCompo;
    public Boss_AttackSkill boss_Skill;
    public Boss_Detecting Detecting;
    public SpriteRenderer _sprite;
    public float distanceThreshold = 0.2f;
    public Point point;
    public bool CanAttack = true;
    [SerializeField] private int SkillCount;

    public int health;
    public int damage;


    public BossState attackState;
    [SerializeField] private BossState currentState;
    public BossState lastState;

    [SerializeField] bool MoreAttack;
    private void Awake()
    {


        RbCompo = GetComponent<Rigidbody2D>();
        AniCompo = GetComponentInChildren<Boss_Animator>();
        StateCompo = GetComponentInChildren<Boss_StateFactory>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        boss_Skill = GetComponent<Boss_AttackSkill>();
        Detecting = GetComponentInChildren<Boss_Detecting>();
        attackState = StateCompo.Boss_GetState(Boss_StateType.Attack);


        attackState.OnAttack1 += boss_Skill.Minimob_Skill1;
        attackState.OnAttack2 += boss_Skill.Minimob_Skill2;
        attackState.OnAttack3 += boss_Skill.Minimob_Skill3;
       
    }

    private void Start()
    {
        health = 300;
        minimob = GetComponentInParent<Transform>();
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
        currentState.StateUpdate();
        if(Input.GetKeyDown(KeyCode.D))
        {
            health -= 1000;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            attackState.OnAttack1.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            attackState.OnAttack2.Invoke();
        }
        Flip();
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate();
    }
 
    public void ChoseRandomAttack()
    {
       
        if(CanAttack)
        {
            CanAttack = false;

            if (Detecting.melee_Attack)
            {
                attackState.OnAttack2.Invoke();
            }
            else
            {
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
                    print("attack3¾øÀ½");
                    attackState.OnAttack1.Invoke();
                }


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
                _sprite.flipX = false;


            }
            else
            {
                _sprite.flipX = true;

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
