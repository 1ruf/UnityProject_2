using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class GameOverManagement : MonoBehaviour
{
    [SerializeField] private List<RectTransform> _sceneBars;
    [SerializeField] private List<TMP_Text> _buttons;
    [SerializeField] private TMP_Text _title, _subTitle;
    [SerializeField] private HGScene1 _glitchManager;
    private void Awake()
    {
        _title.text = "";
        //_subTitle.text = "";

    }
    private void OnEnable()
    {
        PauseUI.IsGameover = true;
        GameOverUICall();
    }

    private IEnumerator UISequence()
    {
        foreach (RectTransform bar in _sceneBars)
        {
            bar.DOScaleY(1, 1f);
        }
        yield return new WaitForSecondsRealtime(1.3f);
        StartCoroutine(DoText(_title, "GAME OVER", 1f));
        yield return new WaitForSeconds(1.5f);
        _title.GetComponent<RectTransform>().DOMoveY(750, 1f);
        yield return new WaitForSeconds(1f);
        ButtonShow();
    }

    private void ButtonShow()
    {
        foreach (TMP_Text img in _buttons)
        {
            img.transform.parent.gameObject.SetActive(true);
            img.DOFade(1, 1f);
        }
    }

    private IEnumerator DoText(TMP_Text text, string endValue, float duration)
    {
        string nowString = null;
        WaitForSeconds charPerTime = new WaitForSeconds(duration / endValue.Length);


        print(endValue.Length);
        for (int i = 0; i < endValue.Length; i++)
        {
            nowString += endValue[i];
            text.text = nowString;
            yield return charPerTime;
        }
    }


    public void GameOverUICall()
    {
        StartCoroutine(UISequence());
    }

    public void RestartBtnClicked()
    {
        DisableBtn();
        Disappear(0,SceneManager.GetActiveScene().name);
    }
    public void Exit2MenuBtnClicked()
    {
        DisableBtn();
        Disappear(0,"MenuScene");
    }
    public void ExitBtnClicked()
    {
        Application.Quit();
    }








    private void Disappear(float time,string scene)
    {
        _title.DOFade(0, 1f);
        foreach (TMP_Text txt in _buttons)
        {
            txt.transform.parent.gameObject.SetActive(false);
            txt.DOFade(0, 1f).OnComplete(() => {
                StartCoroutine(Sceneloader(time, scene));
                PauseUI.IsGameover = false;
            });
        }
    }
    private IEnumerator Sceneloader(float time, string scene)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(scene);
    }

    private void DisableBtn()
    {
        foreach (TMP_Text txt in _buttons)
        {
            txt.transform.parent.GetComponent<Button>().enabled = false;
        }
    }
}
