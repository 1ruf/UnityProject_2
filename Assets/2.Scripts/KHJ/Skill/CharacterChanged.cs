using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanged : MonoBehaviour
{



    public void CharacterChange(Player agent, KSB_Enemy enemy)
    {
        agent.GetComponent<SpriteRenderer>().sprite = enemy.;
        agent.transform.position = enemy.transform.position;
        agent.RbCompo.velocity = Vector2.zero;
        print("º¯°æ");
    }
}
