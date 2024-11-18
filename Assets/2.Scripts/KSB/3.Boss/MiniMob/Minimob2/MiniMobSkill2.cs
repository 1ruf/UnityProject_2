using System.Collections;
using UnityEngine;

public class MiniMobSkill2 : Boss_AttackSkill
{
    [Header("��ų 1 ����")]
    [SerializeField] private GameObject bullet; // �߻��� �Ѿ�
    [SerializeField] private Transform pos;    // �Ѿ� �߻� ��ġ
    [SerializeField] private GameObject AttackSign; // ���� �� ǥ��

    [Header("Setting")]
    private Rigidbody2D _rigid;               // ���� ����
    private Boss_Detecting _Detecting;        // Ÿ�� Ž��
    private Boss_Animator _AniCompo;          // �ִϸ��̼� ����

    private void Awake()
    {
        // ������Ʈ �ʱ�ȭ
        _rigid = GetComponentInParent<Rigidbody2D>();
        _Detecting = GetComponentInChildren<Boss_Detecting>();
        _AniCompo = GetComponentInChildren<Boss_Animator>();
    }

    // ��ų1: ���Ÿ� �Ѿ� �߻�
    public override void Minimob_Skill1()
    {
        StartCoroutine(Shoot());
    }

    // ��ų2: ���� ����
    public override void Minimob_Skill2()
    {
        StartCoroutine(MeleeAttack());
    }

    // ��ų3: ���� ����
    public override void Minimob_Skill3()
    {
        StartCoroutine(Dash());
    }

    private void Update()
    {
        // ���� ���� ���� �� �̵� ����
        if (_Detecting.melee_Attack)
        {
            _rigid.velocity = Vector2.zero;
        }
    }

    // ==================== ��ų1: �Ѿ� �߻� ====================
    private IEnumerator Shoot()
    {
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack3); // ���� �ִϸ��̼� ����
        float startTime = Time.time;

        while (_Detecting.target != null && !_Detecting.melee_Attack)
        {
            if (Time.time - startTime >= 5) 
            {
                break;
            }

            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position; // Ÿ�� ���� ���

            if (direction.sqrMagnitude > 0.0f) // Ÿ�� ������ �����ϸ�
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction); // ���⿡ �°� ȸ��
                pos.rotation = rotation;
            }

            // �Ѿ� �߻�
            Instantiate(bullet, pos.position, pos.rotation);
            yield return new WaitForSeconds(0.8f); // ���� �ð� �������� �߻�
        }

        yield return new WaitForSeconds(1); // ��� ���
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run)); // �̵� ���·� ��ȯ
        _minimob.CanAttack = true;
    }

    // ==================== ��ų2: ���� ���� ====================
    private IEnumerator MeleeAttack()
    {
        if (!_minimob._sprite.flipX)
            _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L); // ���� ����
        else
        {
            _minimob._sprite.flipX = false; // ������ ����
            _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);
        }

        yield return new WaitForSeconds(1.01f); // ���� �� ���
        _minimob.CanAttack = true;
    }

    // ==================== ��ų3: ���� ���� ====================
    private IEnumerator Dash()
    {
        AttackSign.SetActive(true); // ���� ǥ�� Ȱ��ȭ

        yield return new WaitForSeconds(0.5f); // ��� �� ���� ����
        if (_Detecting.target)
        {
            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position; // Ÿ�� ���� ���
            _rigid.velocity = direction * 12; // ���� �ӵ� ����

            // ���� �ִϸ��̼�
            if (!_minimob._sprite.flipX)
                _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);
            else
            {
                _minimob._sprite.flipX = false;
                _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);
            }
        }
        else
        {
            // Ÿ���� ������ �޸��� ���·� ��ȯ
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
            AttackSign.SetActive(false);
            _minimob.CanAttack = true;
        }

        yield return new WaitForSeconds(1); // ���� �� ���
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run)); // �ٽ� �޸��� ���·�
        AttackSign.SetActive(false);
        _minimob.CanAttack = true;
    }
}
