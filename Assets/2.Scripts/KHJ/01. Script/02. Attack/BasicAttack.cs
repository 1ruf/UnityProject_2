using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    static public BasicAttack Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(this);
        else
            Instance = this;
    }

    private Transform target;

    public void Attack(Vector2 point, Vector2 size, float damage, string targetTag)
    {
        Collider2D[] findTarget = Physics2D.OverlapBoxAll(point, size, 0);

        foreach (Collider2D item in findTarget)
        {
                print(item.transform);
            if (item.CompareTag(targetTag))
            {
                target = item.transform;
                break;
            }
        }

        if (!target) return;

        target.GetComponent<Entity>().TakeDamage(damage);

    }

}
