using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] public Vector3[] points;
    private Vector3 _currentPos;
   

    private void Start()
    {
        _currentPos = transform.position;
    
    }


    private void OnDrawGizmos()
    {

        _currentPos = transform.position;

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(points[i] + _currentPos, 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + _currentPos, points[i + 1] + _currentPos);
            }
        }

    }
   
}
