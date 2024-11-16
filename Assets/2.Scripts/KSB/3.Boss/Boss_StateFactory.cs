using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_StateFactory : MonoBehaviour
{
    [SerializeField] private BossState Idle, Attack, Run, Death, Hit,Move;

    public BossState Boss_GetState(Boss_StateType type)
     => type switch
     {
         Boss_StateType.Attack => Attack,
         Boss_StateType.Idle => Idle,
         Boss_StateType.Run => Run,
         Boss_StateType.Hit => Hit,
         Boss_StateType.Death => Death,
         Boss_StateType.Move => Move,

         _ => throw new Exception("State not defined")

     };
}

public enum Boss_StateType
{
   
    Attack,
    Run,
    Idle,
    Death,
    Hit,
    Move
}
