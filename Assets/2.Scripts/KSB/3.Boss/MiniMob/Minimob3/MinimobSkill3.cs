using System.Collections;
using UnityEngine;

public class MiniMobSkill3 : Boss_AttackSkill
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject bullet2;
    [SerializeField] private Transform posUp;
    [SerializeField] private Transform posDown;
    [SerializeField] private GameObject AttackSign;
    [SerializeField] private float AttackSpeed;

    public override void Minimob_Skill1()
    {
        StartCoroutine(ShootUp());
    }

    public override void Minimob_Skill3()
    {
        StartCoroutine(ShootDown());
    }
    private void Update()
    {

    }

    IEnumerator ShootUp()
    {
      
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_L);

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
                posUp.rotation = rotation;
            }

            Instantiate(bullet, posUp.position, posUp.rotation);
            yield return new WaitForSeconds(AttackSpeed);
        }
        yield return new WaitForSeconds(1.3f);
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        _minimob.CanAttack = true;
    }


    IEnumerator ShootDown()
    {
      
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack1_R);

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
                posDown.rotation = rotation;
            }

            Instantiate(bullet2, posDown.position, posDown.rotation);
            yield return new WaitForSeconds(AttackSpeed);
        }
        yield return new WaitForSeconds(1.3f);
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Run));
        _minimob.CanAttack = true;
    }


}
