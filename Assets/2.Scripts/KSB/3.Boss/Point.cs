using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Vector3 point;
    private void Update()
    {
        point = transform.position;
    }
}
