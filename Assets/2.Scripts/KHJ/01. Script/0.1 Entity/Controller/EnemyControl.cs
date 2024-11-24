using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Entity _entity;
    private Transform target;

    private void Awake()
    {
        _entity = GetComponentInChildren<Entity>();
    }
    
    private void Update()
    {
        Collider2D[] findTarget = Physics2D.OverlapBoxAll(transform.position, transform.localScale * 4, 0);

        foreach (Collider2D item in findTarget)
        {
            if (item.CompareTag("Player"))
            {
                target = item.transform;
                break;
            }
        }

        if (!target) return;
        
        _entity.SetMoveDire((target.position - transform.position).normalized);

        float d = Vector2.Distance(_entity.transform.position, target.position);
        if (d < 1.5f)
        {
            _entity.Attack();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale * 4); // 네모(사각형) 그리기
    }



}
