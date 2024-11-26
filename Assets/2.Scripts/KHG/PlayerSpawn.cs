using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject orc1, orc2, orc3, lucy4, skel5;

    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        _playerController._currentEntity = CloneEntity();
    }

    private Entity CloneEntity()
    {
        GameObject clone = SetPlayer();
        clone.transform.position = transform.position;
        return clone.GetComponent<Entity>();
    }

    private GameObject SetPlayer()
    {
        GameObject nowPlr = null;
        switch (SaveManager.Instance.CheckCharacter())
        {
            case Datas.Char_orc1:
                nowPlr = Instantiate(orc1, null);
                break;
            case Datas.Char_orc2:
                nowPlr = Instantiate(orc2, null);
                break;
            case Datas.Char_orc3:
                nowPlr = Instantiate(orc3,null);
                break;
            case Datas.Char_lucy:
                nowPlr = Instantiate(lucy4, null);
                break;
            case Datas.Char_Skel:
                nowPlr = Instantiate(skel5, null);
                break;
        }
        return nowPlr;
    }
}
