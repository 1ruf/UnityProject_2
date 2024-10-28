using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanged : MonoBehaviour
{



    public void CharacterChange(Player agent, KSB_Enemy enemy)
    {
        agent.GetComponent<SpriteRenderer>().sprite = enemy.Visual_Sprite;
        agent.transform.position = enemy.transform.position;
        agent.RbCompo.velocity = Vector2.zero;
        enemy.gameObject.SetActive(false);
        print("º¯°æ");
    }
}
