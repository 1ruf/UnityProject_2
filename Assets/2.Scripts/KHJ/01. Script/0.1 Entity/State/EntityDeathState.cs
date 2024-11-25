using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDeathState : EntityState
{
    protected override void EnterState()
    {
        _entity._enemycontol.enabled = false;
        _entity.gameObject.tag = "Untagged";
        _entity.RbCompo.velocity = Vector2.zero;
        _entity.AnimCompo.PlayAnimaton(AnimationType.death);


        if (_entity.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.enabled = false;
            GameOver();
        }
    }


    private void GameOver() // 게임 오버 따로 만들고 여기서 호출 
    {

    }
}
