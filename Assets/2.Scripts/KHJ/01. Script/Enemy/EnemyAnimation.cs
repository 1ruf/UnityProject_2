using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : NpcAnimation
{
    

    public override void PlayAnimaton(AnimationType animtype)
    {
        switch (animtype)
        {
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.move:
                Play("Walk");
                break;
            case AnimationType.attack:
                Play("RangeAttack");
                break;
            case AnimationType.hit:
                Play("Hit");
                break;
            case AnimationType.death:
                Play("Death");
                break;
            default:
                break;
        }
    }

    internal void InvokeEnemyAnimationAction() // 애니메이션 액션시 호출
    {
        OnAnimationAction?.Invoke();
    }

    internal void InvokeEnemyAnimationEnd() // 애니메이션 끝나면 호출
    {
        print("애니메이션 끝남");
        OnAnimationEnd?.Invoke(); // 이벤트
    }

    public void ResetEvent()
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }
}


