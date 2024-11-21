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
                Play("Move");
                break;
            case AnimationType.attack:
                Play("Attack");
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
}


