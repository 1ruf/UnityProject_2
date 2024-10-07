using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestAgentRotation : MonoBehaviour
{

    
    public UnityEvent<Vector2> onPointerChange;

    private Camera mainCam;
    private void Start()
    {
        mainCam = Camera.main;
    }
    private void Update()
    {
        GetMouseInput();
    }
    public void GetMouseInput()
    {
        Vector2 mouseXY = mainCam.ScreenToWorldPoint(Input.mousePosition);  
        onPointerChange?.Invoke(mouseXY);
    }
}
