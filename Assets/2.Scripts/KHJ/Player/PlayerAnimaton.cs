using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimaton : MonoBehaviour
{
    private Animator _animator;

    public UnityEvent OnAnimationEnd;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }



    public void PlayAnimaton(AnimatonType animtype)
    {
        switch (animtype)
        {
            case AnimatonType.idle:
                Play("Idle");
                break;
            case AnimatonType.walk:
                Play("Walk");
                break;
            case AnimatonType.attack:
                Play("Attack");
                break;
            case AnimatonType.skillUp:
                Play("SkillUp");
                break;
            case AnimatonType.skillDown:
                Play("SkillDown");
                break;
        }
    }



    private void Play(string animName)
    {
        _animator.Play(animName);
    }

    public void Stop()
    {
        _animator.enabled = false;
    }

    public void InvokeAnimationAction()
    {
        OnAnimationAction?.Invoke();
    }

    public void InvokeAnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }

    public void ResetEvent()
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }

}


public enum AnimatonType
{
    idle,
    walk,
    attack,
    skillUp,
    skillDown
}