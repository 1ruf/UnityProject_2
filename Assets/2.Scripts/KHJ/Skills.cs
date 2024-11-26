using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    static public Skills Instance;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;
    }


    private Vector2 _size;
    private Color _color;
    private float _animSpeed;
    private float damage;

    [SerializeField] private float duration = 3f;

    public void UseOrcSkill(Entity Orc)
    {
        _size = Orc.transform.localScale;
        _color = Orc.GetComponent<SpriteRenderer>().color;

        Orc.AnimCompo.Animator.speed = 2.5f;
        Orc.Data.Damage = 16;
        Orc.GetComponent<SpriteRenderer>().color = Color.red;
        Orc.transform.localScale *= 1.2f;
        StartCoroutine(EndSkill(Orc));

    }

    IEnumerator EndSkill(Entity Orc)
    {
        yield return new WaitForSeconds(duration);
        Orc.transform.localScale = _size;
        Orc.Data.Damage = damage;
        Orc.AnimCompo.Animator.speed = _animSpeed;
        Orc.GetComponent<SpriteRenderer>().color = _color;
    }
}
