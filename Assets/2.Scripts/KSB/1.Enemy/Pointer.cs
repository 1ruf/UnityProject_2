using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] public Vector3[] points;

    //public Vector3[] Points { get { return points; } }
    public Vector3[] Points => points;
    public Vector3 CurrentPos => _currentPos;

    //게임 오브젝트 transform 변경 시 기즈모도 같이 움직이게
    private Vector3 _currentPos;
    private bool _gameStarted;

    private void Start()
    {
        _currentPos = transform.position;
        _gameStarted = true;
    }


    private void OnDrawGizmos()
    {
        if (!_gameStarted && transform.hasChanged)
        {
            _currentPos = transform.position;
        }

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

    public Vector3 GetWaypointPosition(int index)
    {
        return points[index] + _currentPos;
    }
}
