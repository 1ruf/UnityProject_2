using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Boss1Skill : Boss_AttackSkill
{
    [Header("��ų 1 ����")]
    [SerializeField] private float spawnDuration;
    [SerializeField] private float spawnInterval = 0.7f;
    [SerializeField] private GameObject minimob;
    [SerializeField] private float radius;

    [Header("��ų 2 ����")]
    [SerializeField] private float skill1RadiusMax = 5f;
    private float skill1RadiusCurrent = 0f;

    [Header("��ų 3 ����")]
    [SerializeField] private float rotationSpeed; // 1600
    [SerializeField] private float shootInterval; // 0.4, 0.3
    [SerializeField] private GameObject shootSign; // 0.4, 0.3

    [SerializeField] private bool changePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject[] shootPosObject;
    [SerializeField] private float shootDuration = 6f;

    [Header("�Ϲ� ����")]
    [SerializeField] private LayerMask targetLayer;
    private float currentTime = 0;
    private Transform[] bulletPositions;
    private GameObject currentPos;
    private GameObject minimobCase;

    public Rigidbody2D rigid;
    public Boss_Detecting detecting;
    public Boss_Animator aniCompo;

    private void Start()
    {
        currentPos = shootPosObject[0];
    }

    private void Awake()
    {
        minimobCase = GameObject.Find("MinimobCase");
        rigid = GetComponentInParent<Rigidbody2D>();
        detecting = GetComponentInChildren<Boss_Detecting>();
        aniCompo = GetComponentInChildren<Boss_Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            print("����");
            changePos = !changePos;
        }
    }

    // ==================== �ʱ�ȭ ====================
    private void InitializeShootPositions()
    {
        bulletPositions = currentPos.GetComponentsInChildren<Transform>()
                                    .Where(t => t != currentPos.transform)
                                    .ToArray();

        if (bulletPositions.Length == 0)
        {
            Debug.LogWarning("�ڽ� ��ü�� �����ϴ�.");
        }
    }

    // ==================== ��ų �޼ҵ� ====================
    public override void Boss_Skill1()
    {
        Debug.Log("��ų 1 �ߵ�");
        StartCoroutine(SpawnMin(spawnInterval, spawnDuration));
    }

    public override void Boss_Skill2()
    {
        StartCoroutine(ShootBullets());
    }

    public override void Boss_Skill3()
    {
        StartCoroutine(IncreaseRadius());
    }

    public override void Boss_Skill4()
    {
        StartCoroutine(Attack1());
    }

    // ==================== ��ų1 ====================
    private IEnumerator IncreaseRadius()
    {
        Debug.Log("������ ���� ����");
        aniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack3);

        while (skill1RadiusCurrent < skill1RadiusMax)
        {
            transform.position = Vector2.MoveTowards(transform.position, detecting.target.transform.position, 0.5f);
            skill1RadiusCurrent += Time.deltaTime * 1.2f;
            yield return null;
        }

        ApplyRadiusEffect();
        ResetRadius();
        _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Run));
        _boss.CanAttack = true;
    }

    private void ApplyRadiusEffect()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, skill1RadiusCurrent, targetLayer);
        if (targetCollider != null)
        {
            GameObject target = targetCollider.gameObject;
            // Ÿ���� ü�� ���� ó��
        }
    }

    private void ResetRadius()
    {
        skill1RadiusCurrent = 0;
    }

    // ==================== ��ų2 ====================
    private IEnumerator ShootBullets()
    {
        shootSign.SetActive(true);
        aniCompo.Play("Boss_Down");
        yield return new WaitForSeconds(0.8f);

        int value = UnityEngine.Random.Range(0, 2);
        changePos = (value == 1);

        rigid.velocity = Vector2.zero;
        GetCurrentPosSetting();

        float startTime = Time.time;
        while (Time.time - startTime < shootDuration)
        {
            rigid.velocity = Vector2.zero;
            RotateShoot(rotationSpeed);
            SpawnBullets();
            yield return new WaitForSeconds(shootInterval);
        }

        currentPos.SetActive(false);
        shootSign.SetActive(false);
        _boss.CanAttack = true;
        _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Idle));
    }

    private void RotateShoot(float speed)
    {
        currentPos.transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    private void SpawnBullets()
    {
        foreach (Transform bulletPos in bulletPositions)
        {
            Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        }
    }

    // ==================== ��ġ ���� ====================
    private int GetCurrentPosSetting()
    {
        Func<int> returnBasedOnAddpos = () => changePos ? 1 : 0;
        int count = returnBasedOnAddpos();

        if (count == 0)
        {
            rotationSpeed = 1600;
            shootInterval = 0.25f;
        }
        else
        {
            rotationSpeed = 800;
            shootInterval = 0.25f;
        }

        currentPos.SetActive(false);
        currentPos = shootPosObject[count];
        InitializeShootPositions();
        currentPos.SetActive(true);
        return count;
    }

    private void OnDrawGizmos()
    {
        if (_boss == null) return;

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(_boss.transform.position, skill1RadiusCurrent);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_boss.transform.position, radius);
    }

    // ==================== �̴Ͼ� ���� ====================
    private IEnumerator SpawnMin(float interval, float spawnDuration)
    {
        aniCompo.Boss_PlayAnimaton(Boss_AnimationType.Spawn);
        WaitForSeconds wait = new WaitForSeconds(interval);
        currentTime = 0;

        while (currentTime <= spawnDuration)
        {
            Vector2 randomPosition = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * radius;
            Instantiate(minimob, randomPosition, _boss.transform.rotation, minimobCase.transform);
            print("�̴Ͼ� ����");

            yield return wait;
            currentTime += interval;
        }
        _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Idle));
        _boss.CanAttack = true;
        currentTime = 0;
    }

    // ==================== ����1 ====================
    private IEnumerator Attack1()
    {
        Debug.Log("����1 �ߵ�");
        if (!_boss._sprite.flipX)
            aniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);
        else
        {
            _boss._sprite.flipX = false;
            aniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);
        }

        yield return new WaitForSeconds(1.05f);
        _boss.CanAttack = true;
        _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Idle));
    }
}
