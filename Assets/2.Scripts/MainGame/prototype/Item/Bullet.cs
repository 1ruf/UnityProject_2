using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpd;
    [SerializeField] private Transform _effectPrefab;
    private Rigidbody2D _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _rigid.AddForce(transform.right * _bulletSpd);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Well"))
        {
            Transform _effect = Instantiate(_effectPrefab);
            _effect.position = transform.position;
            Destroy(gameObject);
            Destroy(_effect.gameObject, 0.5f);
        }
    }
}
