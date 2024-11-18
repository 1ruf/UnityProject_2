using System.Collections;
using UnityEngine;

public class MiniMobSkill3 : Boss_AttackSkill
{
    [SerializeField] private GameObject bullet;      // 위쪽 총알
    [SerializeField] private GameObject bullet2;     // 아래쪽 총알
    [SerializeField] private Transform posUp;       // 위쪽 발사 위치
    [SerializeField] private Transform posDown;     // 아래쪽 발사 위치
    [SerializeField] private GameObject AttackSign; // 공격 표시
    [SerializeField] private float AttackSpeed;     // 총알 발사 속도

    [Header("Setting")]
    public Rigidbody2D _rigid;                    
    public Boss_Detecting _Detecting;               // 목표 탐지 컴포넌트
    public Boss_Animator _AniCompo;                 // 애니메이션 컴포넌트

    // 초기화: 각종 컴포넌트들 설정
    private void Awake()
    {
        _rigid = GetComponentInParent<Rigidbody2D>();
        _Detecting = GetComponentInChildren<Boss_Detecting>();
        _AniCompo = GetComponentInChildren<Boss_Animator>();
    }

    // Skill1 (위쪽 총알 발사) 호출
    public override void Minimob_Skill1()
    {
        StartCoroutine(ShootUp());
    }

    // Skill3 (아래쪽 총알 발사) 호출
    public override void Minimob_Skill3()
    {
        StartCoroutine(ShootDown());
    }

    // 위쪽으로 총알을 발사하는 코루틴
    IEnumerator ShootUp()
    {
        // 공격 애니메이션 실행 (위쪽 발사)
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);

        float startTime = Time.time; // 시작 시간 기록

        // 목표가 존재하고 근접 공격이 아닌 동안 반복
        while (_Detecting.target != null && !_Detecting.melee_Attack)
        {
            // 5초가 지나면 공격을 종료
            if (Time.time - startTime >= 5)
            {
                break;
            }

            // 목표의 위치로 방향 벡터 계산
            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position;

            // 목표 방향을 향해 발사 위치를 회전
            if (direction.sqrMagnitude > 0.0f)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                posUp.rotation = rotation;
            }

            // 위쪽에서 총알 발사
            Instantiate(bullet, posUp.position, posUp.rotation);
            yield return new WaitForSeconds(AttackSpeed); // 발사 간격 기다리기
        }

        // 공격 후 잠시 대기
        yield return new WaitForSeconds(1.3f);

        // 공격 종료 후 Idle 애니메이션 실행
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);

        // 상태를 'Run'으로 전환하여 이동 가능 상태로 설정
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        _minimob.CanAttack = true; // 다시 공격 가능 상태
    }

    // 아래쪽으로 총알을 발사하는 코루틴
    IEnumerator ShootDown()
    {
        // 공격 애니메이션 실행 (아래쪽 발사)
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);

        float startTime = Time.time; // 시작 시간 기록

        // 목표가 존재하고 근접 공격이 아닌 동안 반복
        while (_Detecting.target != null && !_Detecting.melee_Attack)
        {
            // 5초가 지나면 공격을 종료
            if (Time.time - startTime >= 5)
            {
                break;
            }

            // 목표의 위치로 방향 벡터 계산
            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position;

            // 목표 방향을 향해 발사 위치를 회전
            if (direction.sqrMagnitude > 0.0f)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                posDown.rotation = rotation;
            }

            // 아래쪽에서 총알 발사
            Instantiate(bullet2, posDown.position, posDown.rotation);
            yield return new WaitForSeconds(AttackSpeed); // 발사 간격 기다리기
        }

        // 공격 후 잠시 대기
        yield return new WaitForSeconds(1.3f);

        // 공격 종료 후 Idle 애니메이션 실행
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);

        // 상태를 'Run'으로 전환하여 이동 가능 상태로 설정
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        _minimob.CanAttack = true; // 다시 공격 가능 상태
    }
}
