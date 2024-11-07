
using UnityEngine;

public class KSB_Enemy : MonoBehaviour
{
    [Header("State")]
    public E_State currentState;
    public E_State previousState;
    public E_State[] States;

    [Header("External access")]
    public EnemyData enemyData;
    public Sprite Visual_Sprite;
    public SpriteRenderer spriteRenderer;

    public EnemyAnimation AnimationCompo { get; set; }
    public Collider2D ColliderCompo { get; set; }
    public Rigidbody2D RbCompo { get; set; }
    public Sensing sensing;
    public Vector3 point;
    public Transform IdlePosition;
    private float hp;

    private void Awake()
    {
        sensing = GetComponentInChildren<Sensing>();
        enemyData = GetComponent<EnemyData>();
        Visual_Sprite = enemyData.Visual;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ColliderCompo = GetComponent<Collider2D>();
        RbCompo = GetComponent<Rigidbody2D>();
        AnimationCompo = GetComponentInChildren<EnemyAnimation>();

        States = new E_State[]
        {
            GetComponent<HitSstate_SB>(),
            GetComponent<MoveState_SB>(),
            GetComponent<AttackState_SB>() ,
            GetComponent<FollowState_SB>(),
            GetComponent<IdleState_SB>(),
            GetComponent<DeathState_SB>()
        };

        foreach (var state in States)
        {
            state?.InitializeState(this);
        }
    }
    public float Hp
    {
        get => hp;
        set
        {
            hp = Mathf.Clamp(value, 0, 100);
            if (hp <= 0)
            {
                TransitionState(GetState<DeathState_SB>());
            }
        }
    }

    private void Start()
    {
        Hp = enemyData.hp;
        TransitionState(GetState<IdleState_SB>());
        spriteRenderer.sprite = Visual_Sprite;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Hp -= 100;
        if (Input.GetKeyDown(KeyCode.W)) TransitionState(GetState<HitSstate_SB>());

        currentState?.StateUpdate();
        point = IdlePosition.position;

        Flip();
        Rotattion(enemyData.target);
    }

    private void FixedUpdate()
    {
        currentState?.StateFixedUpdate();
    }

    internal void TransitionState(E_State desiredState)
    {
        if (desiredState == null || currentState == desiredState) return;

        currentState?.Exit();
        previousState = currentState;
        currentState = desiredState;
        currentState.Enter();
    }




    public T GetState<T>() where T : E_State
    {
        foreach (var state in States)
        {
            if (state is T) return (T)state;
        }
        return null;
    }


    private void Flip()
    {
        if (enemyData.target != null)
        {
            Vector2 direction = (enemyData.target.transform.position - transform.position).normalized;
            Vector2 forward = transform.right;

            float dotProduct = Vector2.Dot(forward, direction);

            if (dotProduct < 0)
            {
                spriteRenderer.flipX = true;
                enemyData.gun.flipY = true;

            }
            else
            {
                spriteRenderer.flipX = false;
                enemyData.gun.flipY = false;
            }
        }
    }


    private void Rotattion(GameObject target)
    {
        if (target == null)
        {
            return; 
        }

        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        enemyData.GunCase.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}



