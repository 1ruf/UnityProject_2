using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    static public Skills Instance;

    float _attackCool = 11;
    public bool _canAttack = true;


    private Vector2 _size;
    private Color _color;
    private float _animSpeed;
    private float _damage;
    private float _speed;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }



    [SerializeField] private float duration = 3f;

    public void UseOrcSkill(Entity Orc)
    {
        if (_canAttack == false) return;
        _size = Orc.transform.localScale;

        _speed = Orc.Data.moveSpeed;
        _size = Orc.transform.localScale;
        _damage = Orc.Data.Damage;
        _animSpeed = 1;
        _color = Orc.GetComponent<SpriteRenderer>().color;

        Orc.SetMoveSpeed(_speed);
        Orc.transform.localScale = _size * 1.2f;
        Orc.Data.Damage = _damage * 1.5f;
        Orc.AnimCompo.Animator.speed = 2.5f;
        Orc.GetComponent<SpriteRenderer>().color = Color.red;

        StartCoroutine(EndSkill(Orc));
        StartCoroutine(AttackCoolTime());
    }

    IEnumerator EndSkill(Entity Orc)
    {
        yield return new WaitForSeconds(duration);
        Orc.transform.localScale = _size;
        Orc.Data.Damage = _damage;
        Orc.AnimCompo.Animator.speed = _animSpeed;
        Orc.GetComponent<SpriteRenderer>().color = _color;
    }

    IEnumerator EndSkill2(Entity Orc)
    {
        yield return new WaitForSeconds(duration);
        Orc.SetMoveSpeed(_speed);
        Orc.transform.localScale = _size;
    }

    IEnumerator AttackCoolTime()
    {
        _canAttack = false;
        yield return new WaitForSeconds(11);
        _canAttack = true;
    }

    internal void ReSetCoolTime()
    {
        StopCoroutine(AttackCoolTime());
        _canAttack = true;
    }


    public void UseLSkill(Entity Orc)
    {
        if (_canAttack == false) return;
        _size = Orc.transform.localScale;

        _speed = Orc.Data.moveSpeed;


        Orc.SetMoveSpeed(_speed +5);
        Orc.transform.localScale = _size * 0.8f;

        StartCoroutine(EndSkill2(Orc));
        StartCoroutine(AttackCoolTime());
    }
}
