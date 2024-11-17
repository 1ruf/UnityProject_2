using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimob_DeathState : BossState
{
   
    private void Awake()
    {
      
    }
    protected override void EnterState()
    {
        _minimob.AniCompo.Boss_PlayAnimaton(Boss_AnimationType.Death);
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Destroy(_minimob.minimob.gameObject);
    }
}
