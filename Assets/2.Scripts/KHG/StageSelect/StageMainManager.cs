using UnityEngine;
using DG.Tweening;

public class StageMainManager : MonoBehaviour
{
    private StageData _stageData;

    private void Awake()
    {
        _stageData = GetComponent<StageData>();

        _stageData.nowStage = Check();
    }
    private int Check()
    {
        if (SaveManager.Instance.CheckData(33))
            return 4;
        else if (SaveManager.Instance.CheckData(32))
            return 3;
        else if (SaveManager.Instance.CheckData(31))
            return 2;
        else if (SaveManager.Instance.CheckData(30))
            return 1;
        else return 0;
    }
}
