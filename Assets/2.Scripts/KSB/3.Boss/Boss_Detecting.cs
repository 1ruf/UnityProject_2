using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Boss_Detecting : MonoBehaviour
{
    private Boss _boss;
    public bool isDetecting;
    public bool startAttack;
    [SerializeField] private float _red_radius;
    [SerializeField] private float _yellow_radius;
    [SerializeField] private LayerMask _player;
    public GameObject target;
    private Vector3 _center;
    public bool melee_Attack;
    void Start()
    {
        _boss = GetComponentInParent<Boss>();
    }

    private void Update()
    {
        _center = _boss.transform.position;
        Detecting();
        AttacRangeDetecting();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_center, _yellow_radius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_center, _red_radius);

    }

    private void Detecting()
    {
        Collider2D detectingTarget = Physics2D.OverlapCircle(_boss.transform.position, _yellow_radius, _player);
        if (detectingTarget != null)
        {
            target = detectingTarget.gameObject;
            isDetecting = true;
        }
        else
        {
            target = null; // 타겟이 범위를 벗어나면 null로 설정
            isDetecting = false;
        }
    }

    private void AttacRangeDetecting()
    {
        Collider2D detectingTarget = Physics2D.OverlapCircle(_boss.transform.position, _red_radius, _player);
        if (detectingTarget != null)
        {
          
            startAttack = true;
        }
        else 
        {
           // 타겟이 범위를 벗어나면 null로 설정
            startAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            melee_Attack = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            melee_Attack = false;
        }
    }
  
}
