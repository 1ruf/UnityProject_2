using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class E_State : MonoBehaviour
{
    protected KSB_Enemy _agent;
    public UnityEvent OnEnter, OnExit;
    protected Sensing _sensing;//State 나갈때
 
    public void InitializeState(KSB_Enemy agent)
    {
        _agent = agent;
    }

    public void Enter()
    {
    
        EnterState();      //상태에 들어가자마다 EnterState 메소드 실행
        _sensing = _agent.gameObject.GetComponentInChildren<Sensing>();
    }

    protected virtual void EnterState()
    {
        //각각 상태에 해당하는 애니메이션 실행 등
    }

    protected virtual void HandleJumpPressed()
    {
    }

    protected virtual void HandleJumpReleased()
    {
    }

    protected virtual void HandleMovement(Vector2 vector)
    {
    }

    public virtual void StateUpdate()
    {
        //상태가 변화하나 기다리고 있음
        //예를들어 idle 상태일 때는 input이 들어오길 기다림
    }

    public virtual void StateFixedUpdate()
    {
        //상태가 변화하나 기다리고 있음
        //예를들어 idle 상태일 때는 input이 들어오길 기다림
    }

    public void Exit()
    {
      
        ExitState();
    }

    protected virtual void ExitState()
    {
    }

   protected virtual void Flip()
    {

        if(_agent.enemyData.target != null)
        {
            Vector2 direction = (_agent.enemyData.target.transform.position - _agent.transform.position);
            Vector2 forward = _agent.transform.right;
            float crossProduct = forward.x * direction.y - forward.y * direction.x;

            if (crossProduct > 0)
            {
                _agent.spriteRenderer.flipX = false;
            }
            else if (crossProduct < 0)
            {
                _agent.spriteRenderer.flipX = true;
            }
        }
      
       
    }

}
