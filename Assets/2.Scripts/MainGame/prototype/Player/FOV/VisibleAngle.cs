using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleAngle : MonoBehaviour
{
    [SerializeField] private Transform target; // ���ü��� Ȯ���� ��� ��ü
    private float maxAngle = 50f; // 45���� ����, �� �� ���鿡�� 22.5��
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
