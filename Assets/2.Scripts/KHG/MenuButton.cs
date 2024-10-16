using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI, startMenuUI,settingMenuUI;
    [SerializeField] private TMP_Text startBtn, settingBtn, quitBtn;

    private void OnEnable()
    {
        StartCoroutine(DoText(startBtn, "start",0.3f));
        StartCoroutine(DoText(settingBtn, "setting",0.5f));
        StartCoroutine(DoText(quitBtn, "quit",0.7f));
    }
    public void StartBtnClicked()
    {
        startMenuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void SettingBtnClicked()
    {
        settingMenuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void ExitBtnClicked()
    {
        Application.Quit();
    }
    private IEnumerator DoText(TMP_Text text, string endValue, float duration)
    {
        string tempString = null;
        WaitForSeconds charPerTime = new WaitForSeconds(duration / endValue.Length);

        for (int i = 0; i < endValue.Length; i++)
        {
            tempString += endValue[i];
            text.text = tempString;

            yield return charPerTime;
        }
    }
}
