using UnityEngine;
using DG.Tweening;

public class StageMainManager : MonoBehaviour
{
    private StageData _stageData;

    private void Awake()
    {
        _stageData = GetComponent<StageData>();
        _stageData.nowStage = PlayerPrefs.GetInt("NowSavedStage");
    }
}
