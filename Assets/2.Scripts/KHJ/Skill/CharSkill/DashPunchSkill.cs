using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPunchSkill : MonoBehaviour
{
    [SerializeField] private float _distance = 5f;
    [SerializeField] private Transform _slashEffectPrefab;
    [SerializeField] private Vector2 _slashSize;

    public void SkillPlay(Player agent)
    {
        Vector3 direction = new Vector3((agent.GetComponent<SpriteRenderer>().flipX ? -1 : 1) * _distance, 0, 0);


        agent.transform.position += direction;
        Transform _slash = Instantiate(_slashEffectPrefab, null);
        _slash.position = agent.transform.position + -direction;
        _slash.localScale = _slashSize;
        _slash.GetComponent<SpriteRenderer>().flipX = agent.GetComponent<SpriteRenderer>().flipX ? false : true;
        Destroy(_slash.gameObject, 0.55f); // 이펙트가 끝나는 시간에 정확히 삭제
    }

    
}
