using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class look : MonoBehaviour
{
    private float desiredAngle;
    public void AimWeapon(Vector2 pointPos)
    {
        Vector2 aimDir = (Vector3)pointPos - transform.position;
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);  
    }
}
