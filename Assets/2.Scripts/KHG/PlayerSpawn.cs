using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Cr1, Cr2, Cr3, Cr4, Cr5;

    [SerializeField] private PlayerController _playerController;

    private void OnEnable()
    {
        _playerController._currentEntity = SetPlayer();
    }
    private GameObject SetPlayer()
    {
        GameObject nowPlr = null;
        switch (SaveManager.Instance.CheckCharacter())
        {
            case Datas.Char_orc1:
                nowPlr = Cr1;
                break;
            case Datas.Char_orc2:
                nowPlr = Cr2;
                break;
            case Datas.Char_orc3:
                nowPlr = Cr3;
                break;
            case Datas.Char_lucy:
                nowPlr = Cr4;
                break;
            case Datas.Char_Skel:
                nowPlr = Cr5;
                break;
        }
        return nowPlr;
    }
}
