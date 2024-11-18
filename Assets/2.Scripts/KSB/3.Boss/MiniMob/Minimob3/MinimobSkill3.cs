using System.Collections;
using UnityEngine;

public class MiniMobSkill3 : Boss_AttackSkill
{
    [SerializeField] private GameObject bullet;      // ���� �Ѿ�
    [SerializeField] private GameObject bullet2;     // �Ʒ��� �Ѿ�
    [SerializeField] private Transform posUp;       // ���� �߻� ��ġ
    [SerializeField] private Transform posDown;     // �Ʒ��� �߻� ��ġ
    [SerializeField] private GameObject AttackSign; // ���� ǥ��
    [SerializeField] private float AttackSpeed;     // �Ѿ� �߻� �ӵ�

    [Header("Setting")]
    public Rigidbody2D _rigid;                    
    public Boss_Detecting _Detecting;               // ��ǥ Ž�� ������Ʈ
    public Boss_Animator _AniCompo;                 // �ִϸ��̼� ������Ʈ

    // �ʱ�ȭ: ���� ������Ʈ�� ����
    private void Awake()
    {
        _rigid = GetComponentInParent<Rigidbody2D>();
        _Detecting = GetComponentInChildren<Boss_Detecting>();
        _AniCompo = GetComponentInChildren<Boss_Animator>();
    }

    // Skill1 (���� �Ѿ� �߻�) ȣ��
    public override void Minimob_Skill1()
    {
        StartCoroutine(ShootUp());
    }

    // Skill3 (�Ʒ��� �Ѿ� �߻�) ȣ��
    public override void Minimob_Skill3()
    {
        StartCoroutine(ShootDown());
    }

    // �������� �Ѿ��� �߻��ϴ� �ڷ�ƾ
    IEnumerator ShootUp()
    {
        // ���� �ִϸ��̼� ���� (���� �߻�)
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);

        float startTime = Time.time; // ���� �ð� ���

        // ��ǥ�� �����ϰ� ���� ������ �ƴ� ���� �ݺ�
        while (_Detecting.target != null && !_Detecting.melee_Attack)
        {
            // 5�ʰ� ������ ������ ����
            if (Time.time - startTime >= 5)
            {
                break;
            }

            // ��ǥ�� ��ġ�� ���� ���� ���
            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position;

            // ��ǥ ������ ���� �߻� ��ġ�� ȸ��
            if (direction.sqrMagnitude > 0.0f)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                posUp.rotation = rotation;
            }

            // ���ʿ��� �Ѿ� �߻�
            Instantiate(bullet, posUp.position, posUp.rotation);
            yield return new WaitForSeconds(AttackSpeed); // �߻� ���� ��ٸ���
        }

        // ���� �� ��� ���
        yield return new WaitForSeconds(1.3f);

        // ���� ���� �� Idle �ִϸ��̼� ����
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);

        // ���¸� 'Run'���� ��ȯ�Ͽ� �̵� ���� ���·� ����
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        _minimob.CanAttack = true; // �ٽ� ���� ���� ����
    }

    // �Ʒ������� �Ѿ��� �߻��ϴ� �ڷ�ƾ
    IEnumerator ShootDown()
    {
        // ���� �ִϸ��̼� ���� (�Ʒ��� �߻�)
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);

        float startTime = Time.time; // ���� �ð� ���

        // ��ǥ�� �����ϰ� ���� ������ �ƴ� ���� �ݺ�
        while (_Detecting.target != null && !_Detecting.melee_Attack)
        {
            // 5�ʰ� ������ ������ ����
            if (Time.time - startTime >= 5)
            {
                break;
            }

            // ��ǥ�� ��ġ�� ���� ���� ���
            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position;

            // ��ǥ ������ ���� �߻� ��ġ�� ȸ��
            if (direction.sqrMagnitude > 0.0f)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                posDown.rotation = rotation;
            }

            // �Ʒ��ʿ��� �Ѿ� �߻�
            Instantiate(bullet2, posDown.position, posDown.rotation);
            yield return new WaitForSeconds(AttackSpeed); // �߻� ���� ��ٸ���
        }

        // ���� �� ��� ���
        yield return new WaitForSeconds(1.3f);

        // ���� ���� �� Idle �ִϸ��̼� ����
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);

        // ���¸� 'Run'���� ��ȯ�Ͽ� �̵� ���� ���·� ����
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        _minimob.CanAttack = true; // �ٽ� ���� ���� ����
    }
}
