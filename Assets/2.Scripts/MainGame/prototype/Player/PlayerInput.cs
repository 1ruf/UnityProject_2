using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Gun scrWeapon;

    private Camera mainCam;

    public UnityEvent<Vector2> onPointerChange;
    public Vector2 moveDir { get; private set; }
    private void Start()
    {
        mainCam = Camera.main;
    }
    private void Update()
    {
        GetMouseInput();
        MoveInput();
        TestInput();
    }

    private void TestInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            scrWeapon.CheckAmmo();
        }
    }

    public void MoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(x, y);
    }
    public void GetMouseInput()
    {
        Vector2 mouseXY = mainCam.ScreenToWorldPoint(Input.mousePosition);
        onPointerChange?.Invoke(mouseXY);
    }
}
