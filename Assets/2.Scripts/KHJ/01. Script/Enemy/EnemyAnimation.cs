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

    internal void InvokeEnemyAnimationAction() // �ִϸ��̼� �׼ǽ� ȣ��
    {
        OnAnimationAction?.Invoke();
    }

    internal void InvokeEnemyAnimationEnd() // �ִϸ��̼� ������ ȣ��
    {
        print("�ִϸ��̼� ����");
        OnAnimationEnd?.Invoke(); // �̺�Ʈ
    }

    public void ResetEvent()
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }
}


