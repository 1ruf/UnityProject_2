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
        //2번째 엘리베이터에서 스폰 && 씬 넘어가는 컷씬 실행
        if (elevator == 1)
        {
            //엘리베이터 1(동력 무제한)
        }
        else if (elevator == 2)
        {
            //엘리베이터 2(동력 제한)
        }
    }
}
