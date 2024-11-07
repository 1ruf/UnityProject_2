using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class E_State : MonoBehaviour
{
    protected KSB_Enemy _agent;
    protected Boss _boss;
    protected Sensing _sensing;

    public void InitializeState(KSB_Enemy agent)
    {
        _agent = agent;
    }

    public void Enter()
    {
        _sensing = _agent.sensing;  
        EnterState(); 
       
    }

    protected virtual void EnterState()
    {
        
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

   
}
