using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EntityData")]
public class EntityData : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public Sprite skillImage;
    public float Damage;
    public float maxHp;
    public float moveSpeed;
}
