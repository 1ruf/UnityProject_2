using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcAnimation : MonoBehaviour
{
    protected Animator _animator;

    public event Action OnAnimationEnd;
    public event Action OnAnimationAction;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }




    public virtual void PlayAnimaton(AnimationType animtype)
    {
        
    }



    protected virtual void Play(string animName)
    {
    }

    public virtual void Stop()
    {
        _animator.enabled = false;
    }

    public virtual void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }

    public virtual void InvokeAnimationEnd()
    {
        OnAnimationAction?.Invoke();
    }

    
}
public enum AnimationType
{
    idle,
    move,
    attack,
    death,
    hit,
}


