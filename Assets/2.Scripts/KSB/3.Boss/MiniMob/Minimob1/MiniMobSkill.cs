using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMobSkill1 :Boss_AttackSkill
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pos;


    public override void Minimob_Skill1()
    {
        StartCoroutine(Shoot());
    }

    public override void Minimob_Skill2() 
    {
        StartCoroutine(Shock());
    }

    private void Update()
    {
      
    }

    IEnumerator Shoot()
    {
      
        while(_minimob.Detecting.target!=null&&!_minimob.Detecting.melee_Attack)
        {
            _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Idle);
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

    IEnumerator Shock()
    {
        print("D");
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Attack2);

        yield return new WaitForSeconds(1.01f);
        _minimob.TransitionState(_minimob.StateCompo.Boss_GetState(Boss_StateType.Death));
        _minimob.CanAttack = true;
    }

}
