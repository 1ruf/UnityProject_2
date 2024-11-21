using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public EnemyStateFectory StateCompo { get; protected set; }
    public EnemyAnimation AnimCompo { get; protected set; }

    public Transform Target { get; private set; }

    private void Awake()
    {
        StateCompo = GetComponentInChildren<EnemyStateFectory>();
        AnimCompo = GetComponent<EnemyAnimation>();
        RbCompo = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void Start()
    {
        StateCompo.InitializeState(this);
        TransitionState(StateCompo.GetState(StateType.Idle));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Target = collision.transform;

            float d = Vector2.Distance(Target.position, transform.position);

            if (d < 10)
            {
                CanAttack = true;
            }
            else
            {
                CanAttack = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == Target)
        {
            Target = null;
            CanAttack = false;
        }
    }
}

