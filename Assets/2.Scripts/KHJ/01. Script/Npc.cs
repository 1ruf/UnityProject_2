using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public State CurrentState { get; protected set; }
    public State PreviousState { get; protected set; }

    public bool CanAttack { get; protected set; }


    public Flip FlipCompo;

    
    public Rigidbody2D RbCompo { get; protected set; }
    protected SpriteRenderer _spriteRenderer;

    


    

    private void FixedUpdate()
    {
        CurrentState.StateFixedUpdate();
    }

    private void Update()
    {
        CurrentState.StateUpdate();
        FlipCompo.FlipNpc(this);
    }

    internal void TransitionState(State desireState)
    {
        if (desireState == null) return;

        if (CurrentState != null)
        {
            CurrentState.Exit();
            PreviousState = CurrentState;
        }
        CurrentState = desireState;
        CurrentState.Enter();
    }
}
