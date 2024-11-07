using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_StateFactory : MonoBehaviour
{
    [SerializeField] private E_State Idle, Attack, Run, Death, Hit;

    public E_State Boss_GetState(Boss_StateType type)
     => type switch
     {
         Boss_StateType.Attack => Attack,
         Boss_StateType.Idle => Idle,
         Boss_StateType.Run => Run,
         Boss_StateType.Hit => Hit,
         Boss_StateType.Death => Death,
         _ => throw new Exception("State not defined")

     };
}

public enum Boss_StateType
{
   
    Attack,
    Run,
    Idle,
    Death,
    Hit
}
