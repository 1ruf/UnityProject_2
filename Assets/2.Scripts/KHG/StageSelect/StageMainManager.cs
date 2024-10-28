using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageMainManager : MonoBehaviour
{
    private StageData _stageData;

    private void Awake()
    {
        _stageData = GetComponent<StageData>();
        _stageData.nowStage = PlayerPrefs.GetInt("NowSavedStage");
    }
}
