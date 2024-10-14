using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KHJPlayer : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            print("pressed");
        }
    }
}
