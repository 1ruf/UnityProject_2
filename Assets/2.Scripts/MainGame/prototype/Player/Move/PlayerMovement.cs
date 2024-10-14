using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D _rb2d;
    private PlayerInput plrInput;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        plrInput = GetComponent<PlayerInput>();
    }
    private void FixedUpdate()
    {
        _rb2d.velocity = plrInput.moveDir.normalized * moveSpeed;
    }
}
