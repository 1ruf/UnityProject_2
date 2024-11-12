using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private MenuBGMManager _bgmManager;

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
        if (SaveManager.Instance.CheckData(30))
            continueBtn.interactable = true;
        else
            continueBtn.interactable = false;
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
        gameObject.transform.parent.gameObject.SetActive(false);
        GameStart();
    }
    public void NewGameBtnClicked()
    {
        gameObject.SetActive(false);
        if (SaveManager.Instance.CheckData(30)) //30번째줄에 저장값이 true이면
        {
            WarnPopup(warnMessage[0],warnMessage[1]);
        }
        else
        {
            GameStart();
        }
    }
    private void GameStart()
    {
        _bgmManager.SetVolume(_bgmManager._audio,0f,1f); // 오디오, 목표값,시간, 킬것인가 끌것인가
        mainCam.DOOrthoSize(5f, 2f).OnComplete(()=> SceneManager.LoadScene(1));
    }
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
        gameObject.SetActive(true);
        w_UI.SetActive(false);
    }
    public void W_Reset()
    {
        for (int i = 0; i < 4; i++)
        {
            SaveManager.Instance.CheckData(30 + i);
        }
        ContinueBtnClick();
    }
}
