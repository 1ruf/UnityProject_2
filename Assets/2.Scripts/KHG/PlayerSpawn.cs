using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject orc1, orc2, orc3, lucy4, skel5;

    [SerializeField] private PlayerController _playerController;

    private void OnEnable()
    {
        _playerController._currentEntity = SetPlayer().GetComponent<Entity>();
    }
    private GameObject SetPlayer()
    {
        GameObject nowPlr = null;
        switch (SaveManager.Instance.CheckCharacter())
        {
            case Datas.Char_orc1:
                nowPlr = orc1;
                break;
            case Datas.Char_orc2:
                nowPlr = orc2;
                break;
            case Datas.Char_orc3:
                nowPlr = orc3;
                break;
            case Datas.Char_lucy:
                nowPlr = lucy4;
                break;
            case Datas.Char_Skel:
                nowPlr = skel5;
                break;
        }
        return nowPlr;
    }
}
