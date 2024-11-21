using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : State
{
    protected override void EnterState()
    {
        print("데스 스테이트");
    }
}
