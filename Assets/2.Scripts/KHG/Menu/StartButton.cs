using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private TMP_Text continueBtn, newgameBtn, backBtn;

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

    }
    public void NewGameBtnClicked()
    {

    }
    public void BackBtnClicked()
    {
        mainMenuUI.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
