using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleAngle : MonoBehaviour
{
    [SerializeField] private Transform target; // 가시성을 확인할 대상 객체
    private float maxAngle = 50f; // 45도의 절반, 즉 각 측면에서 22.5도
    private bool isVisible;

    void Update()
    {
        CheckVisibility();
        print(isVisible);
    }

    void CheckVisibility()
    {
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.Normalize();

        Vector3 rotatedDirection = Quaternion.Euler(0, 0, 90) * transform.right;

        float angle = Vector3.Angle(rotatedDirection, directionToTarget);

        if (angle <= maxAngle)
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }
    }
}
