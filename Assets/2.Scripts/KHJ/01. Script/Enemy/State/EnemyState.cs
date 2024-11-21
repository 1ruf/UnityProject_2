using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    protected Enemy _enemy;
    public void InitializeState(Enemy enemy)
    {
        _enemy = enemy;
    }
}
