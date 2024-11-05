using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class E_State : MonoBehaviour
{
    protected KSB_Enemy _agent;
    public UnityEvent OnEnter, OnExit;
    protected Sensing _sensing;//State ������


    public void InitializeState(KSB_Enemy agent)
    {
        _agent = agent;
    }

    public void Enter()
    {

        EnterState();      //���¿� ���ڸ��� EnterState �޼ҵ� ����
        _sensing = _agent.gameObject.GetComponentInChildren<Sensing>();
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

   
}
