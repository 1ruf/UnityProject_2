using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ElevatorManager : MonoBehaviour
{
    [SerializeField] private Datas _nextMap;
    [SerializeField] private Image _blocker;

    private bool _powered;


    public void ElevatorPowerOn()
    {
        _powered = true;
    }
    public void PowerElevatorConnect(GameObject trigger)
    {
        if (_powered == true)
        {
            StartCoroutine(nextStage());
        }
        else
        {
            trigger.SetActive(true);
        }
    }
    public void ElevatorConnect()
    {
        StartCoroutine(nextStage());
    }
    private IEnumerator nextStage()
    {
        SaveManager.Instance.SetData((int)Datas.Char_orc1, true);
        _blocker.DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        SaveManager.Instance.SetData((int)_nextMap, true);
        SceneManager.LoadScene(_nextMap.ToString());
    }
}
