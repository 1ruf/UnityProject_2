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
    public void PowerElevatorConnect()
    {
        if (_powered == true)
        {
            StartCoroutine(nextStage());
        }
    }
    public void ElevatorConnect()
    {
        StartCoroutine(nextStage());    
    }
    private IEnumerator nextStage()
    {
        print("¥Ÿ¿Ω Ω∫≈◊¿Ã¡ˆ");
        _blocker.DOFade(1, 1f);
        yield return new WaitForSeconds(1.2f);
        //ø§∏Æ∫£¿Ã≈Õ æ¿ ø¿«¬
        yield return new WaitForSeconds(0.8f);
        _blocker.DOFade(0, 1f);
        yield return new WaitForSeconds(4f);
        _blocker.DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        SaveManager.Instance.SetData((int)_nextMap, true);
        SceneManager.LoadScene(_nextMap.ToString());
    }
}
