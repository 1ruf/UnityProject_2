using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectorBulletSkill : MonoBehaviour
{

    [SerializeField] private Transform _bulletPrefab;
    public void SkillPlay(Player agent) // 전기 총알 생성 함수 (졸개1을 해킹한 상태에서 사용
    {
        agent.RbCompo.velocity = Vector2.zero;
        Vector3 direction = ((Vector3)agent.InputCompo.MousePos - agent.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Transform bullet = Instantiate(_bulletPrefab, transform.parent.position, Quaternion.Euler(0, 0, angle));
        bullet.LookAt(agent.InputCompo.MousePos);
    }
}
