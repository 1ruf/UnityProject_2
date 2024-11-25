using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityAnimation : MonoBehaviour
{
    protected Animator _animator;

    public UnityEvent OnAnimationEnd;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //_animator.SetFloat("", );
    }


    protected void Play(string animName)
    {
        _animator.Play(animName);
    }

    public void Stop()
    {
        _animator.enabled = false;
    }


    public void PlayAnimaton(AnimationType animtype)
    {
        switch (animtype)
        {
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.run:
                Play("Run");
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

    internal void InvokeAnimationAction() // 애니메이션 액션시 호출
    {
        OnAnimationAction?.Invoke();
    }

    internal void InvokeAnimationEnd() // 애니메이션 끝나면 호출
    {
        OnAnimationEnd?.Invoke(); // 이벤트
    }

    public void ResetEvent()
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }

    internal void SetMoveParameters(Vector2 moveDire)
    {
        _animator.SetFloat("MoveX", moveDire.x);
        _animator.SetFloat("MoveY", moveDire.y);
    }
}
public enum AnimationType
{
    idle,
    run,
    attack,
    death,
    hit,
}


