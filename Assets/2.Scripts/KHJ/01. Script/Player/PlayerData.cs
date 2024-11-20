using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static public PlayerData Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }


    public float moveSpeed = 8f;
    public float maxHealth;
    public Vector2 moveDir;
}
