using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.InputSystem;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI, startMenuUI,settingMenuUI;
    [SerializeField] private TMP_Text startBtn, settingBtn, quitBtn;

    private void OnEnable()
    {
        StartCoroutine(DoText(startBtn, "start",0.3f));
        StartCoroutine(DoText(settingBtn, "setting",0.5f));
        StartCoroutine(DoText(quitBtn, "quit",0.7f));
        StartCoroutine(MainTitle(transform.parent.Find("MainTitle").gameObject));
    }
    private IEnumerator MainTitle(GameObject mainTitle)
    {
        mainTitle.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        mainTitle.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        mainTitle.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SaveManager.Instance.SetData(30, true);
        }
    }
    public void StartBtnClicked()
    {
        startMenuUI.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void SettingBtnClicked()
    {
        settingMenuUI.gameObject.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void ExitBtnClicked()
    {
        Application.Quit();
    }
    private IEnumerator DoText(TMP_Text text, string endValue, float duration)
    {
        string nowString = null;
        WaitForSeconds charPerTime = new WaitForSeconds(duration / endValue.Length);

        for (int i = 0; i < endValue.Length; i++)
        {
            nowString += endValue[i];
            text.text = nowString;

            yield return charPerTime;
        }
    }
}
