using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NpcAnimation : MonoBehaviour
{
    protected Animator _animator;

    public UnityEvent OnAnimationEnd;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }




    public virtual void PlayAnimaton(AnimationType animtype)
    {
        
    }



    protected void Play(string animName)
    {
        _animator.Play(animName);
    }

    public void Stop()
    {
        _animator.enabled = false;
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


