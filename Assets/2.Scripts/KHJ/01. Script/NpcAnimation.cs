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



    protected virtual void Play(string animName)
    {
        _animator.Play(animName);
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
        OnAnimationEnd?.Invoke();
    }

    public virtual void ResetEvent()
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }
}
