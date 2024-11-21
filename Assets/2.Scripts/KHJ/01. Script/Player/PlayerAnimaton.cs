using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimaton : NpcAnimation
{
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void PlayAnimaton(AnimationType animtype)
    {
        switch (animtype)
        {
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.walk:
                Play("Walk");
                break;
            case AnimationType.attack:
                Play("Attack");
                break;
            default:
                break;
        }
    }
}


public enum AnimationType
{
    idle,
    walk,
    attack,
}


