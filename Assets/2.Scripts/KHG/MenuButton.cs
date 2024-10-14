using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject startMenuUI;
    public void StartBtnClicked()
    {
        StartCoroutine(fadeOut(mainMenuUI, 0.1f, 2));
    }
    public void ExitBtxClicked()
    {

    }
    private IEnumerator fadeOut(GameObject obj,float time,int repeatCount)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            obj.SetActive(false);
            yield return new WaitForSeconds(time);
            obj.SetActive(true);
        }
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
}
