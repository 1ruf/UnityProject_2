using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityAnimation : MonoBehaviour
{
    public Animator Animator { get; private set; }

    public UnityEvent OnAnimationEnd;
    public UnityEvent OnAnimationAction;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
    }


    protected void Play(string animName)
    {
        Animator.Play(animName);
    }

    public void Stop()
    {
        Animator.enabled = false;
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
            case AnimationType.attack2:
                Play("Attack2");
                break;
            case AnimationType.attack3:
                Play("Attack3");
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

    internal void InvokeAnimationAction() // �ִϸ��̼� �׼ǽ� ȣ��
    {
        OnAnimationAction?.Invoke();
    }

    internal void InvokeAnimationEnd() // �ִϸ��̼� ������ ȣ��A
    {
        OnAnimationEnd?.Invoke(); // �̺�Ʈ
    }

    public void ResetEvent()
    {
        OnAnimationAction.RemoveAllListeners();
        OnAnimationEnd.RemoveAllListeners();
    }

    internal void SetMoveParameters(Vector2 moveDire)
    {
        Animator.SetFloat("MoveX", moveDire.x);
        Animator.SetFloat("MoveY", moveDire.y);
    }
}
public enum AnimationType
{
    idle,
    run,
    attack,
    attack2,
    attack3,
    death,
    hit,
}


