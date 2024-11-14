using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class CS2rolling : MonoBehaviour
{
    [SerializeField] private GameObject _mainTitle, _yesBtn, _noBtn;
    [SerializeField] private GameObject _phoneIdleImg;
    [SerializeField] private GameObject _phoneCallingImg;

    private int progress;
    private TMP_Text _mainText;
    private RectTransform _mainTitleRT;
    private Button _yBtxt, _nBtxt;
    private void Awake()
    {
        ButtonSet(false);
        _yBtxt = _yesBtn.GetComponent<Button>();
        _nBtxt = _noBtn.GetComponent<Button>();
        _phoneIdleImg.SetActive(true);
        _phoneCallingImg.SetActive(false);
        _mainText = _mainTitle.GetComponent<TMP_Text>();
        _mainTitleRT = _mainTitle.GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        Progressing();
    }




    //--------------------------------------------Progresses-------------------------------------------------
    private IEnumerator Progress1()
    {
        yield return new WaitForSeconds(1f);
        _phoneCallingImg.SetActive(true);
        StartCoroutine(DoText(_mainText,"(휴대폰이 울린다)",0.3f));
        ButtonSet(true,"전화를 받는다","전화를 받지 않는다");
    }
    private IEnumerator Progress2()
    {
        _phoneCallingImg.GetComponent<Image>().DOFade(0, 1f);
        StartCoroutine(DoText(_mainText, "...", 1f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(DoText(_mainText, "혹시 ㅁㅁㅁ되시나요?", 0.3f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "아, 저는 회사TCR회장님의 비서입니다.", 0.5f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "ㅁㅁㅁ님은 해킹에 실력이 높으시다고 들었습니다만, 저희를 좀 도와주실수 있으신가요?", 1f));
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(DoText(_mainText, "물론, 돈은 충분히 드릴겁니다.", 1f));

        ButtonSet(true, "수락한다", "거절한다");
    }
    private IEnumerator DeProgress1()
    {
        StartCoroutine(DoText(_mainText, "...", 1.5f));
        _phoneCallingImg.SetActive(false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Progress1());
    }
    private void DefaulProgress()
    {
        StartCoroutine(DoText(_mainText, "잠깐....뭔가 이상한데........", 1f));
        ButtonSet(true,"???","???");
    }
    public void Progressing()
    {
        ButtonSet(false);
        switch (progress)
        {
            case 0:
                StartCoroutine(Progress1());
                progress++;
                break;
            case 1:
                StartCoroutine(Progress2());
                progress++;
                break;
            default:
                DefaulProgress();
                progress++;
                break;
        }
    }
    public void Denide()
    {
        ButtonSet(false);
        switch (progress)
        {
            case 1:
                StartCoroutine(DeProgress1());
                break;
            default:
                DefaulProgress();
                break;
        }
    }
    //-------------------------------------------------------------------------------------------------------



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

    private void ButtonSet(bool value,string yesText = "예", string noText = "아니오")
    {
        _noBtn.SetActive(value);
        _noBtn.transform.Find("TM").GetComponent<TMP_Text>().text = noText;
        _yesBtn.SetActive(value);
        _yesBtn.transform.Find("TM").GetComponent<TMP_Text>().text = yesText;
    }
}
