using System.Collections;
using UnityEngine;

public class MiniMobSkill2 : Boss_AttackSkill
{
    [Header("스킬 1 설정")]
    [SerializeField] private GameObject bullet; // 발사할 총알
    [SerializeField] private Transform pos;    // 총알 발사 위치
    [SerializeField] private GameObject AttackSign; // 공격 시 표시

    [Header("Setting")]
    private Rigidbody2D _rigid;               // 물리 연산
    private Boss_Detecting _Detecting;        // 타겟 탐지
    private Boss_Animator _AniCompo;          // 애니메이션 제어

    private void Awake()
    {
        // 컴포넌트 초기화
        _rigid = GetComponentInParent<Rigidbody2D>();
        _Detecting = GetComponentInChildren<Boss_Detecting>();
        _AniCompo = GetComponentInChildren<Boss_Animator>();
    }

    // 스킬1: 원거리 총알 발사
    public override void Minimob_Skill1()
    {
        StartCoroutine(Shoot());
    }

    // 스킬2: 근접 공격
    public override void Minimob_Skill2()
    {
        StartCoroutine(MeleeAttack());
    }

    // 스킬3: 돌진 공격
    public override void Minimob_Skill3()
    {
        StartCoroutine(Dash());
    }

    private void Update()
    {
        // 근접 공격 중일 때 이동 멈춤
        if (_Detecting.melee_Attack)
        {
            _rigid.velocity = Vector2.zero;
        }
    }

    // ==================== 스킬1: 총알 발사 ====================
    private IEnumerator Shoot()
    {
        _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack3); // 공격 애니메이션 시작
        float startTime = Time.time;

        while (_Detecting.target != null && !_Detecting.melee_Attack)
        {
            if (Time.time - startTime >= 5) 
            {
                break;
            }

            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position; // 타겟 방향 계산

            if (direction.sqrMagnitude > 0.0f) // 타겟 방향이 존재하면
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction); // 방향에 맞게 회전
                pos.rotation = rotation;
            }

            // 총알 발사
            Instantiate(bullet, pos.position, pos.rotation);
            yield return new WaitForSeconds(0.8f); // 일정 시간 간격으로 발사
        }

        yield return new WaitForSeconds(1); // 잠시 대기
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run)); // 이동 상태로 전환
        _minimob.CanAttack = true;
    }

    // ==================== 스킬2: 근접 공격 ====================
    private IEnumerator MeleeAttack()
    {
        if (!_minimob._sprite.flipX)
            _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L); // 왼쪽 공격
        else
        {
            _minimob._sprite.flipX = false; // 오른쪽 공격
            _AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);
        }

        yield return new WaitForSeconds(1.01f); // 공격 후 대기
        _minimob.CanAttack = true;
    }

    // ==================== 스킬3: 돌진 공격 ====================
    private IEnumerator Dash()
    {
        AttackSign.SetActive(true); // 공격 표시 활성화

        yield return new WaitForSeconds(0.5f); // 대기 후 돌진 시작
        if (_Detecting.target)
        {
            GameObject target = _Detecting.target;
            Vector3 direction = target.transform.position - transform.position; // 타겟 방향 계산
            _rigid.velocity = direction * 12; // 돌진 속도 설정

            // 돌진 애니메이션
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
            // 타겟이 없으면 달리기 상태로 전환
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
            AttackSign.SetActive(false);
            _minimob.CanAttack = true;
        }

        yield return new WaitForSeconds(1); // 돌진 후 대기
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run)); // 다시 달리기 상태로
        AttackSign.SetActive(false);
        _minimob.CanAttack = true;
    }
}
