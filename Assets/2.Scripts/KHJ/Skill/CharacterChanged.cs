using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanged : MonoBehaviour
{

    [SerializeField] private Transform _clone;

    public void CharacterChange(Player agent, KSB_Enemy enemy)
    {
        CharCreate(agent);

        agent.AnimCompo.Stop();
        agent.GetComponent<SpriteRenderer>().sprite = enemy.Visual_Sprite;
        agent.transform.position = enemy.transform.position;
        agent.transform.localScale = enemy.transform.localScale;
        agent.RbCompo.velocity = Vector2.zero;
        enemy.gameObject.SetActive(false);
        print("º¯°æ");
    }


    private void CharCreate(Player agent)
    {
        Transform clone = Instantiate(_clone, null);
        clone.GetComponent<SpriteRenderer>().sprite = agent.GetComponent<SpriteRenderer>().sprite;
        clone.transform.position = agent.transform.position;
        clone.localScale = agent.transform.localScale;
        clone.gameObject.SetActive(true);
    }


}
