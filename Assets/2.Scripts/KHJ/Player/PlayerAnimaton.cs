using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaton : MonoBehaviour
{
    private Animator _animator;

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
}


public enum AnimatonType
{
    idle,
    walk,
    attack
}