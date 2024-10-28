using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Enemy")]
public class EnemySO :ScriptableObject
{

    public Sprite Visual;

    public float damage = 2;
    public int hp = 100;
    public float speed = 3;
    public float detecting_Range = 6.5f;

    
   

}
