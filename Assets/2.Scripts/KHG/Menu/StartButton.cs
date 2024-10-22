using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class StartButton : MonoBehaviour
{
    [Header("warn message")]
    [SerializeField] private GameObject w_UI;
    [SerializeField] private TMP_Text w_title;
    [SerializeField] private TMP_Text w_message;
    [Header("button")]
    [SerializeField] private Button continueBtn;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private List<TMP_Text> BtnTxt = new List<TMP_Text>();
    [Header("etc.")]
    [SerializeField] private Camera mainCam;
    [SerializeField] private string[] warnMessage;

    private void Awake()
    {
        w_UI.SetActive(false);
        mainMenuUI.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(DoText(BtnTxt[0], "continue", 0.3f));
        StartCoroutine(DoText(BtnTxt[1], "new game", 0.5f));
        StartCoroutine(DoText(BtnTxt[2], "back", 0.7f));
        SetBtn();
    }

    private void SetBtn()
    {
        if (PlayerPrefs.GetInt("NowSavedStage") != 0)
            continueBtn.enabled = false;
        else
            continueBtn.enabled = true;
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
    public void ContinueBtnClick()
    {
        mainCam.DOOrthoSize(5f, 2f);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    public void NewGameBtnClicked()
    {
        gameObject.SetActive(false);
        int savedData = PlayerPrefs.GetInt("NowSavedStage",0);
        if (savedData == 0)
        {
            GameStart();
        }
        else
        {
            WarnPopup(warnMessage[0],warnMessage[1]);
        }
    }
    private void GameStart()
    {
        mainCam.DOOrthoSize(5f, 2f);    }
    public void BackBtnClicked()
    {
        mainMenuUI.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    private void WarnPopup(string Title, string message)
    {
        w_UI.SetActive(true);
        w_title.text = Title;
        w_message.text = message;
    }
    public void W_BackBtnClicked()
    {
        gameObject.transform.parent.gameObject.SetActive(true);
        w_UI.SetActive(false);
    }
    public void W_Reset()
    {
        PlayerPrefs.SetInt("NowSavedStage", 0);
        ContinueBtnClick();
    }
}
