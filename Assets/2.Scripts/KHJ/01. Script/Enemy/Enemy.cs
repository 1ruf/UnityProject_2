using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public override bool CanAttack { get; protected set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform target = collision.transform;

            float d = Vector2.Distance(target.position, transform.position);

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
        CanAttack = false;
    }
}

