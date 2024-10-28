using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class E_State : MonoBehaviour
{
    protected KSB_Enemy _agent;
    public UnityEvent OnEnter, OnExit;  //State ������
    public void InitializeState(KSB_Enemy agent)
    {
        _agent = agent;
    }

    public void Enter()
    {
  
        EnterState();      //���¿� ���ڸ��� EnterState �޼ҵ� ����
    }

    protected virtual void EnterState()
    {
        //���� ���¿� �ش��ϴ� �ִϸ��̼� ���� ��
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
        //���°� ��ȭ�ϳ� ��ٸ��� ����
        //������� idle ������ ���� input�� ������ ��ٸ�
    }

    public virtual void StateFixedUpdate()
    {
        //���°� ��ȭ�ϳ� ��ٸ��� ����
        //������� idle ������ ���� input�� ������ ��ٸ�
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

        if(_agent.target != null)
        {
            Vector2 direction = (_agent.target.transform.position - _agent.transform.position);
            Vector2 forward = _agent.transform.right;
            float crossProduct = forward.x * direction.y - forward.y * direction.x;

            if (crossProduct > 0)
            {
                _agent.spriteRender.flipX = false;
            }
            else if (crossProduct < 0)
            {
                _agent.spriteRender.flipX = true;
            }
        }
      
       
    }

}
