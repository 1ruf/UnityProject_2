using UnityEngine;

public class Boss : MonoBehaviour
{
    public Rigidbody2D RbCompo;
    public Boss_Animator AniCompo;
    public Boss_StateFactory StateCompo;
    public AttackSkillFactory AttackStillCompo;

    [SerializeField] private Boss1_AttackState attackState;
    public Boss_AttackSkill attackSkill;
    private string bossName;
    private float _attackDelay;

    [SerializeField] private E_State currentState;

    private void Awake()
    {

        bossName = gameObject.name;
        RbCompo = GetComponent<Rigidbody2D>();
        AniCompo = GetComponent<Boss_Animator>();
        StateCompo = GetComponent<Boss_StateFactory>();
        attackState = GetComponent<Boss1_AttackState>();
        attackSkill = GetComponent<Boss_AttackSkill>();

        attackState.OnAttack1 += AttackStillCompo.GetSkill(bossName).Skill1;
        attackState.OnAttack2 += AttackStillCompo.GetSkill(bossName).Skill2;
        attackState.OnAttack3 += AttackStillCompo.GetSkill(bossName).Skill3;


    }

    private void Start()
    {
        TransitionState(StateCompo.Boss_GetState(Boss_StateType.Idle));
        attackState.OnAttack1 = attackSkill.Skill1;
    }

    public void TransitionState(E_State InputState)
    {
        if (InputState == null)
            return;
        if (currentState != InputState)
            return;
        currentState.Exit();
        currentState = InputState;
        currentState.Enter();

    }

    private void Update()
    {

        currentState.StateUpdate();
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
        float AttackType = Random.Range(0, 3);

        switch (AttackType)
        {
            case 0:
                attackState.OnAttack1.Invoke();
                break;
            case 1:
                attackState.OnAttack2.Invoke();
                break;
            case 2:
                attackState.OnAttack3.Invoke();
                break;


        }

    }


}
