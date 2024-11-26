using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    static public Skills Instance;

    float _attackCool = 11;
    private bool _canAttack = true;


    private Vector2 _size;
    private Color _color;
    private float _animSpeed;
    private float _damage;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }



    [SerializeField] private float duration = 3f;

    public void UseOrcSkill(Entity Orc)
    {
        _size = Orc.transform.localScale;


        _size = Orc.transform.localScale;
        _damage = Orc.Data.Damage;
        _animSpeed = 1;
        _color = Orc.GetComponent<SpriteRenderer>().color;


        Orc.transform.localScale = _size * 1.2f;
        Orc.Data.Damage = _damage * 1.5f;
        Orc.AnimCompo.Animator.speed = 3;
        Orc.GetComponent<SpriteRenderer>().color = Color.red;

        StartCoroutine(EndSkill(Orc));
    }

    IEnumerator EndSkill(Entity Orc)
    {
        yield return new WaitForSeconds(duration);
        Orc.transform.localScale = _size;
        Orc.Data.Damage = _damage;
        Orc.AnimCompo.Animator.speed = _animSpeed;
        Orc.GetComponent<SpriteRenderer>().color = _color;
        StartCoroutine(AttackCoolTime());
    }

    IEnumerator AttackCoolTime()
    {
        _canAttack = false;
        yield return new WaitForSeconds(11);
        _canAttack = true;
    }


}
