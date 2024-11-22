using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public EnemyStateFectory StateCompo { get; protected set; }
    public EnemyAnimation AnimCompo { get; protected set; }

    [SerializeField] public Transform Target;

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

    private void Update()
    {
        if (Target == null) return;
        float d = Vector2.Distance(transform.position, Target.position);

        if (d < 3)
            CanAttack = true;
        else
            CanAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Target == collision.transform)
        {
            Target = null;
            CanAttack = false;
        }
    }
}

