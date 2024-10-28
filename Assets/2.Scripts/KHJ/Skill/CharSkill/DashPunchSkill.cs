using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPunchSkill : MonoBehaviour
{
    [SerializeField] private float _distance = 5f;


    public void SkillPlay(Player agent)
    {
        Vector3 direction = new Vector3((agent.GetComponent<SpriteRenderer>().flipX ? -1 : 1) * _distance, 0, 0);

        agent.transform.position += direction;

    }
}
