using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Boss_Detecting : MonoBehaviour
{
    private Boss _boss;
    private Minimob _minimob;
    public bool isDetecting;
    public bool startAttack;
    [SerializeField] private float _red_radius;
    [SerializeField] private float _yellow_radius;
    [SerializeField] private LayerMask _player;
    public GameObject target;
    private Vector3 _center;
    public bool melee_Attack;
    private Transform _mytransform;
    
    void Start()
    {
        _boss = GetComponentInParent<Boss>();
        _minimob = GetComponentInParent<Minimob>();

        if(_boss)
            _mytransform =_boss.transform;
        else
            _mytransform = _minimob.transform;


    }

    private void Update()
    {
        _center = _mytransform.position;
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
        Collider2D detectingTarget = Physics2D.OverlapCircle(_mytransform.position, _yellow_radius, _player);
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
        Collider2D detectingTarget = Physics2D.OverlapCircle(_mytransform.position, _red_radius, _player);
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
