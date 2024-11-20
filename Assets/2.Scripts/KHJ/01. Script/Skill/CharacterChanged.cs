using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanged : MonoBehaviour
{

    [SerializeField] private Transform _clone;

    public void ChangeCharacter(Npc npc, Enemy enemy)
    {
        CreateCharcter(npc); // �÷��̾� ���� ����� �޼���
        npc.gameObject.tag = "Enemy";
        npc.AnimCompo.Stop();
        //npc.GetComponent<SpriteRenderer>().sprite = enemy.Visual_Sprite;
        npc.transform.position = enemy.transform.position;
        npc.transform.localScale = enemy.transform.localScale;
        npc.RbCompo.velocity = Vector2.zero;
        enemy.gameObject.SetActive(false);
    } // �÷��̾� ���̸� ����� ���ܵΰ�, ������ ������ (���� ��Ȱ��ȭ) 


    private void CreateCharcter(Npc agent)
    {
        Transform clone = Instantiate(_clone, null);
        clone.gameObject.SetActive(true);
        clone.GetComponent<SpriteRenderer>().sprite = agent.GetComponent<SpriteRenderer>().sprite;
        clone.transform.position = agent.transform.position;
        clone.localScale = agent.transform.localScale;
        clone.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1f); // ȸ��. ���ʹ� ������ ó�� ǥ��
    }


}
