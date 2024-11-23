using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField] private Interactable _interact;
    private bool _powered;


    public void ElevatorPowerOn()
    {
        _powered = true;
    }
    public void PowerElevatorConnect()
    {
        if (_powered == true)
        {
            nextStage(1);
        }
    }
    public void ElevatorConnect()
    {
        nextStage(2);
    }
    private void nextStage(int elevator)
    {
        //2��° ���������Ϳ��� ���� && �� �Ѿ�� �ƾ� ����
        if (elevator == 1)
        {
            //���������� 1(���� ������)
        }
        else if (elevator == 2)
        {
            //���������� 2(���� ����)
        }
    }
}
