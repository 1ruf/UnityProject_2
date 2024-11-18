using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class CS2rolling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    [SerializeField] private GameObject _mainTitle, _yesBtn, _noBtn;
    [SerializeField] private GameObject _phoneIdleImg;
    [SerializeField] private GameObject _phoneCallingImg;

    [SerializeField] private Image _blocker;

    private string userName;
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
        _blocker.DOFade(0, 0.5f);
        userName = SaveManager.Instance.GetData((int)Datas.Username);
        Progressing();
    }

    //안녕하십니까? TCR고객센터입니다. 상담원과 연결중이니 잠시만 기다려 주십시오.


    //--------------------------------------------Progresses-------------------------------------------------
    private IEnumerator Progress1()
    {
        yield return new WaitForSeconds(1f);
        _phoneCallingImg.SetActive(true);
        StartCoroutine(DoText(_mainText,"(휴대폰이 울린다)",0.3f));
        ButtonSet(true,"전화를 받는다","전화를 받지 않는다");
    }   //case 0
    private IEnumerator Progress2()
    {
        _phoneIdleImg.SetActive(false);
        _phoneCallingImg.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        StartCoroutine(DoText(_mainText, "...", 1f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(DoText(_mainText, "혹시 '"+ userName + "'님 되시나요?", 0.5f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "아, 저는 회사TCR회장님의 비서입니다.", 0.7f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "'"+userName+"'님은 해킹에 실력이 높으시다고 들었습니다만, 저희를 좀 도와주실수 있으신가요?", 2f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "물론, 돈은 충분히 드릴겁니다.", 1f));

        ButtonSet(true, "수락한다", "거절한다");
    }   //case 1
    private IEnumerator Progress3()
    {
        StartCoroutine(DoText(_mainText, "좋습니다.", 0.5f));
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(DoText(_mainText, "그럼 현재 저희의 상황을 설명해드리겠습니다.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "먼저 저희 회사에 대해 알고 계신가요?", 0.7f));
        yield return new WaitForSeconds(0.7f);
        ButtonSet(true, "안다", "모른다");
    }   //case 2
    private IEnumerator Progress4()
    {
        StartCoroutine(DoText(_mainText, "그럼 현재 상황을 말씀드리겠습니다.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "현재 저희 회사는 알수없는것으로부터 공격을 받아 로봇들을 통제할수 없는 상태입니다.", 2.5f));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(DoText(_mainText, "불행중 다행으로 저희 로봇들을 회사 밖으로는 나가지 않고 활성화된 로봇도 회사 내부에만 있는 상태입니다.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "이 로봇들을 해킹 해주시면 됩니다.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "회사 전체를 멈추거나 해킹하시면 회사 내에 있는 데이터가 손성될 우려가 있으므로 전체를 해킹해선 안됩니다.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "그리고 기본적인 로봇은 저희가 제공해 드리죠.", 1.2f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "그럼 잘 부탁드립니다.", 1.2f));
        yield return new WaitForSeconds(2f);
        GameStart();
    } //case 3
    private IEnumerator DeProgress1()   //case 0
    {
        StartCoroutine(DoText(_mainText, "...전화를 끊었다.", 1.5f));
        _phoneCallingImg.SetActive(false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Progress1());
    }
    private IEnumerator DeProgress2()   //case 1
    {
        StartCoroutine(DoText(_mainText, "아...", 1.5f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "흠...뭐....", 2f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "어쩔수 없죠 뭐", 1f));
        _phoneIdleImg.SetActive(false);
        _phoneCallingImg.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(DoText(_mainText, "(전화가 끊겼다.)", 1f)); //엔딩
    }
    private IEnumerator DeProgress3()
    {
        StartCoroutine(DoText(_mainText, "저희는 전투용 로봇을 만드는 TCR(Tactical Combat Robot)입니다.", 2f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "현재 저희 회사는 알수없는것으로부터 공격을 받아 로봇들을 통제할수 없는 상태입니다.", 2.5f));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(DoText(_mainText, "불행중 다행으로 저희 로봇들을 회사 밖으로는 나가지 않고 활성화된 로봇도 회사 내부에만 있는 상태입니다.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "이 로봇들을 해킹 해주시면 됩니다.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "회사 전체를 멈추거나 해킹하시면 회사 내에 있는 데이터가 손성될 우려가 있으므로 전체를 해킹해선 안됩니다.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "그리고 기본적인 로봇은 저희가 제공해 드리죠.", 1.2f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "그럼 잘 부탁드립니다.", 1.2f));
        yield return new WaitForSeconds(2f);
        GameStart();
    }//case 2
    private void DefaulProgress()
    {
        StartCoroutine(DoText(_mainText, "잠깐....뭔가 이상한데........", 1f));
        ButtonSet(true,"???","???");
    }
    public void Progressing()
    {
        print("현재 케이스:" + progress);
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
            case 2:
                StartCoroutine(Progress3());
                progress++;
                SaveManager.Instance.SetData((int)Datas.Stage1, true);
                break;
            case 3:
                StartCoroutine(Progress4());
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
        print("현재 케이스:" + progress);
        ButtonSet(false);
        switch (progress)
        {
            case 1:
                StartCoroutine(DeProgress1());
                break;
            case 2:
                StartCoroutine(DeProgress2());
                break;
            case 3:
                StartCoroutine(DeProgress3());
                progress++;
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
            _audio.pitch = Random.Range(0.90f, 1.00f);
            _audio.Play();

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

    private void GameStart()
    {
        _blocker.DOFade(1, 0.5f);
        //delay
        SaveManager.Instance.SetData((int)Datas.Cutscene1, true);
    }
}
