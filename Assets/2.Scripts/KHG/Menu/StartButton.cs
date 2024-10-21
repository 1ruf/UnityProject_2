using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private TMP_Text continueBtn, newgameBtn, backBtn;
    [SerializeField] private string[] warnMessege;

    private void OnEnable()
    {
        StartCoroutine(DoText(continueBtn, "continue", 0.3f));
        StartCoroutine(DoText(newgameBtn, "new game", 0.5f));
        StartCoroutine(DoText(backBtn, "back", 0.7f));
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
        int savedData = PlayerPrefs.GetInt("NowSavedStage");
        if (savedData == 0)
        {

        }
        else
        {
            WarnPopup(warnMessege[0],warnMessege[1]);
        }
    }
    public void BackBtnClicked()
    {
        mainMenuUI.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
    private void WarnPopup(string Title, string message)
    {

    }
}
