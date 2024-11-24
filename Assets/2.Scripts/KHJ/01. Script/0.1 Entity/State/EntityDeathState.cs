using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDeathState : EntityState
{
    protected override void EnterState()
    {
        _entity.gameObject.layer = LayerMask.NameToLayer("Default");
        _entity.RbCompo.velocity = Vector2.zero;
        _entity.AnimCompo.PlayAnimaton(AnimationType.death);
        _entity.AnimCompo.OnAnimationAction.AddListener(Death);
    }



    private void Death()
    {
        print("죽음 이벤트 실행하세요");
    }

    protected override void ExitState()
    {
        _entity.AnimCompo.ResetEvent();
    }
}
