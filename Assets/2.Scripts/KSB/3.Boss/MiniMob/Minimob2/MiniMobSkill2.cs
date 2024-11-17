using System.Collections;
using UnityEngine;

public class MiniMobSkill2 : Boss_AttackSkill
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pos;
   [SerializeField] private GameObject AttackSign;


    public override void Minimob_Skill1()
    {
        StartCoroutine(Shoot());
    }

    public override void Minimob_Skill2()
    {
        StartCoroutine(MeleeAttack());
    }

    public override void Minimob_Skill3()
    {
        StartCoroutine(Dash());
    }
    private void Update()
    {
        if(_minimob.Detecting.melee_Attack)
        {
            _minimob.RbCompo.velocity = Vector2.zero;
        }
    }

    IEnumerator Shoot()
    {
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack3);
        float startTime = Time.time;

        while (_minimob.Detecting.target != null && !_minimob.Detecting.melee_Attack)
        {
         
            if (Time.time - startTime >= 5)
            {
                break;
            }

            GameObject target = _minimob.Detecting.target;
            Vector3 direction = target.transform.position - transform.position;

            if (direction.sqrMagnitude > 0.0f)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                pos.rotation = rotation;
            }

            Instantiate(bullet, pos.position, pos.rotation);
            yield return new WaitForSeconds(0.8f);
        }

        
        yield return new WaitForSeconds(1);
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        _minimob.CanAttack = true;
    }


    IEnumerator MeleeAttack()
    {
        if (!_minimob._sprite.flipX)
            _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);
        else
        {
            _minimob._sprite.flipX = false;
            _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);
        }

        yield return new WaitForSeconds(1.01f);
        _minimob.CanAttack = true;
    }

    IEnumerator Dash()
    {
        AttackSign.SetActive(true);
            
        yield return new WaitForSeconds(0.5f);
        if(_minimob.Detecting.target)
        {
            GameObject target = _minimob.Detecting.target;
            Vector3 direction = target.transform.position - transform.position;
            _minimob.RbCompo.velocity = (direction * 12);

            if (!_minimob._sprite.flipX)
                _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);
            else
            {
                _minimob._sprite.flipX = false;
                _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);
            }
        }
        else
        {
            _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
            AttackSign.SetActive(false);
            _minimob.CanAttack = true;
            
        }
        yield return new WaitForSeconds(1);
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        AttackSign.SetActive(false);
        _minimob.CanAttack = true;

    }
}
