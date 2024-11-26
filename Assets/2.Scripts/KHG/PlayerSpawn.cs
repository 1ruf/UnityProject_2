using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void OnEnable()
    {
        switch (SaveManager.Instance.CheckCharacter())
        {
            case Datas.Char_orc1:
                //ø¿≈© 1 currentEntityø° ª¿‘
                break;
            case Datas.Char_orc2:
                break;
            case Datas.Char_orc3:
                break;
            case Datas.Char_lucy:
                break;
            case Datas.Char_Skel:
                break;
        }
        //_playerController._currentEntity = ≈∏∞Ÿ
    }
}
