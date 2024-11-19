using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text _messageTmp;
    [Header("Tutorial Messages")]
    [SerializeField] private string[] _tutorailMessage;

    private int nowMission;

    private void Update()
    {
        
    }
    private void MissionSet()
    {
        switch (nowMission)
        {
            case 0: //기본조작(W,A,S,D)
                break;
            case 1: //
                break;
        }
    }
}
