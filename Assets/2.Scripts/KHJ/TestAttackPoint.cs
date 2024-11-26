using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }
}
