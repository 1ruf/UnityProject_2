using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDeathState : EntityState
{
    protected override void EnterState()
    {
        _entity._enemycontol.enabled = false;
        //if (_entity.gameObject.CompareTag("Player")) PlayerController.Instance.enabled = false;
        _entity.gameObject.layer = LayerMask.NameToLayer("Default");
        _entity.RbCompo.velocity = Vector2.zero;
        _entity.AnimCompo.PlayAnimaton(AnimationType.death);
    }
}
