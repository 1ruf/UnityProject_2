using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Entity _entity;
    private Transform target;

    float _attackWaitTime = 0.3f;
    float _attackCoolTime = 1.5f;

    private bool _canAttack = true;
    private bool _waitAttack = false;

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
        if (!target || _waitAttack) return;

        float d = Vector2.Distance(_entity.transform.position, target.position);
        if (d < 1.5f)
        {
            _entity.SetMoveDire(Vector2.zero);
            if (_canAttack && _entity.StateCompo.StateCheck(_entity.CurrentState))
            {
                StartCoroutine(WaitAttackCorotine());
            }
        }
        else
        {
            _entity.SetMoveDire((target.position - transform.position).normalized);
        }
    }


    IEnumerator AttackCoolCorotine()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCoolTime);
        _canAttack = true;
    }


    IEnumerator WaitAttackCorotine()
    {
        _waitAttack = true;
        StartCoroutine(AttackCoolCorotine());
        yield return new WaitForSeconds(_attackWaitTime);
        _waitAttack = false;
        _entity.Attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale * 4); // 네모(사각형) 그리기
    }



}
