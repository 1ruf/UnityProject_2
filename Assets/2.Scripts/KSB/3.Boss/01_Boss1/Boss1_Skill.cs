using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Boss1Skill : Boss_AttackSkill
{

    [Header("Skill 1 Settings")]
    [SerializeField] float spawnDuration;
    [SerializeField] private float spawnInterval = 0.7f;
    [SerializeField] private GameObject Minimob;
    [SerializeField] private float radius;

    [Header("Skill 2 Settings")]
    [SerializeField] private float skill1RadiusMax = 5f;
    private float skill1RadiusCurrent = 0f;


    [Header("Skill 3 Settings")]
    [SerializeField] private float _rotationSpeed; // 1600
    [SerializeField] private float shootInterval; // 0.4 0.3
    [SerializeField] GameObject ShootSign; // 0.4 0.3



    [SerializeField] private bool changePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject[] shootPosObject;
    [SerializeField] private float shootDuration = 6f;


    [Header("General Settings")]
    [SerializeField] private LayerMask targetLayer;
    private float currentTime = 0;
    private Transform[] bulletPositions;
    private GameObject _currentPos;

    private void Start()
    {
        _currentPos = shootPosObject[0];
    }
    private void Awake()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            print("Change");
            changePos = !changePos;
        }
    }

    // ==================== Initialization ====================
    private void InitializeShootPositions()
    {
        bulletPositions = _currentPos.GetComponentsInChildren<Transform>()
                        .Where(t => t != _currentPos.transform)
                        .ToArray();

        if (bulletPositions.Length == 0)
        {
            Debug.LogWarning("자식 없음");
        }
    }

    // ==================== Skill Methods ====================
    public override void Skill1()
    {
        Debug.Log("100");
        StartCoroutine(SpawnMin(spawnInterval, spawnDuration));
    }

    public override void Skill2()
    {
        StartCoroutine(ShootBullets());
    }

    public override void Skill3()
    {
        StartCoroutine(IncreaseRadius());
    }

    public override void Skill4()
    {
        StartCoroutine(Attack1());
    }

    // ==================== Skill1 ====================
    private IEnumerator IncreaseRadius()
    {
        Debug.Log("5");
        _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack3);

        while (skill1RadiusCurrent < skill1RadiusMax)
        {
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

        }

    }

    private void ResetRadius()
    {
        skill1RadiusCurrent = 0;
    }

    // ==================== Skill2 ====================
    private IEnumerator ShootBullets()
    {
        ShootSign.SetActive(true);
        _boss.AniCompo.Play("Boss_Down");
        yield return new WaitForSeconds(0.8f);
        int value = UnityEngine.Random.Range(0, 2);
        if (value == 1)
        {
            changePos = true;
        }
        else
        {
            changePos = false;
        }
        _boss.RbCompo.velocity = Vector2.zero;
        GetCurrentPosSetting();
        float startTime = Time.time;
        while (Time.time - startTime < shootDuration)
        {
            _boss.RbCompo.velocity = Vector2.zero;
            RotateShoot(_rotationSpeed);
            SpawnBullets();
            yield return new WaitForSeconds(shootInterval);
        }
        _currentPos.SetActive(false);
        ShootSign.SetActive(false);
        _boss.CanAttack = true;
        _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Idle));

    }

    private void RotateShoot(float speed)
    {
        _currentPos.transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    private void SpawnBullets()
    {
        foreach (Transform bulletPos in bulletPositions)
        {
            Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        }
    }

    // ==================== Pos결정 ====================
    private int GetCurrentPosSetting()
    {

        Func<int> returnBasedOnAddpos = () => changePos ? 1 : 0;
        int count = returnBasedOnAddpos();

        if (count == 0)
        {
            _rotationSpeed = 1600;
            shootInterval = 0.25f;
        }
        else
        {
            _rotationSpeed = 800;
            shootInterval = 0.25f;
        }
        _currentPos.SetActive(false);
        _currentPos = shootPosObject[count];
        InitializeShootPositions();
        _currentPos.SetActive(true);
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

    //==================== Minion Spawn ====================
    private IEnumerator SpawnMin(float interval, float spawnDuration)
    {
        _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Spawn);
        WaitForSeconds wait = new WaitForSeconds(interval);
        currentTime = 0;

        while (currentTime <= spawnDuration)
        {
            Vector2 randomPosition = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * radius;
            Instantiate(Minimob, randomPosition, _boss.transform.rotation);
            print("S");

            yield return wait;
            currentTime += interval;
        }
        _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Idle));
        _boss.CanAttack = true;
        currentTime = 0;
    }

    // ==================== Attack1 ====================
    private IEnumerator Attack1()
    {
        Debug.Log("hi");
        if (!_boss._sprite.flipX)
            _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);
        else
        {
            _boss._sprite.flipX = false; //밑에 있는 에니메이션에서 y축으로 180도 회전하기 때문에
            _boss.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);
        }


        yield return new WaitForSeconds(1.05f);
        _boss.CanAttack = true;
        _boss.TransitionState(_boss.StateCompo.Boss_GetState(Boss_StateType.Idle));
    }
}
