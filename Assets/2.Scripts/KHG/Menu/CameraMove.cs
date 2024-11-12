using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _mainCam, _camFollower;
    [SerializeField] private float _camMoveAmount = 20f;
    [SerializeField] private float _camMoveSpeed = 30f;

    private void FixedUpdate()
    {
        SetMousePos();
    }

    private void SetMousePos()
    {
        float x = Mathf.Lerp(_mainCam.position.x, (GetMousePosition().x + _camFollower.position.x) / _camMoveAmount, (Time.deltaTime * _camMoveSpeed));
        float y = Mathf.Lerp(_mainCam.position.y, (GetMousePosition().y + _camFollower.position.y) / _camMoveAmount, (Time.deltaTime * _camMoveSpeed));

        _mainCam.position = new Vector3(x, y, -10f);
    }

    private Vector3 GetMousePosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
