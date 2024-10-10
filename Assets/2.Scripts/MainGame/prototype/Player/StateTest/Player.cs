using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            print("pressed");
        }
    }
}
