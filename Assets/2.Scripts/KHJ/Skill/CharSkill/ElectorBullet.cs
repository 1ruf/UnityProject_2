using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectorBullet : MonoBehaviour // 일반 총알과 다른 점 : 이펙트, 총알 색깔, 총알 맞은 곳 근처의 적을 스턴시킴(아직 미구현)
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
