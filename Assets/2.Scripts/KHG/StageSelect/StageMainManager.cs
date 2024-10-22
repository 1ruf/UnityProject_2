using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainManager : MonoBehaviour
{
    private StageData _stageData;

    private void Awake()
    {
        _stageData = GetComponent<StageData>();
    }
}
