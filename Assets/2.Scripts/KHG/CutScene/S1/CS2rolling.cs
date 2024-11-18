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

    //�ȳ��Ͻʴϱ�? TCR�������Դϴ�. ������ �������̴� ��ø� ��ٷ� �ֽʽÿ�.


    //--------------------------------------------Progresses-------------------------------------------------
    private IEnumerator Progress1()
    {
        yield return new WaitForSeconds(1f);
        _phoneCallingImg.SetActive(true);
        StartCoroutine(DoText(_mainText,"(�޴����� �︰��)",0.3f));
        ButtonSet(true,"��ȭ�� �޴´�","��ȭ�� ���� �ʴ´�");
    }   //case 0
    private IEnumerator Progress2()
    {
        _phoneIdleImg.SetActive(false);
        _phoneCallingImg.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        StartCoroutine(DoText(_mainText, "...", 1f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(DoText(_mainText, "Ȥ�� '"+ userName + "'�� �ǽó���?", 0.5f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "��, ���� ȸ��TCRȸ����� ���Դϴ�.", 0.7f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "'"+userName+"'���� ��ŷ�� �Ƿ��� �����ôٰ� ������ϴٸ�, ���� �� �����ֽǼ� �����Ű���?", 2f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "����, ���� ����� �帱�̴ϴ�.", 1f));

        ButtonSet(true, "�����Ѵ�", "�����Ѵ�");
    }   //case 1
    private IEnumerator Progress3()
    {
        StartCoroutine(DoText(_mainText, "�����ϴ�.", 0.5f));
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(DoText(_mainText, "�׷� ���� ������ ��Ȳ�� �����ص帮�ڽ��ϴ�.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "���� ���� ȸ�翡 ���� �˰� ��Ű���?", 0.7f));
        yield return new WaitForSeconds(0.7f);
        ButtonSet(true, "�ȴ�", "�𸥴�");
    }   //case 2
    private IEnumerator Progress4()
    {
        StartCoroutine(DoText(_mainText, "�׷� ���� ��Ȳ�� �����帮�ڽ��ϴ�.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "���� ���� ȸ��� �˼����°����κ��� ������ �޾� �κ����� �����Ҽ� ���� �����Դϴ�.", 2.5f));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(DoText(_mainText, "������ �������� ���� �κ����� ȸ�� �����δ� ������ �ʰ� Ȱ��ȭ�� �κ��� ȸ�� ���ο��� �ִ� �����Դϴ�.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "�� �κ����� ��ŷ ���ֽø� �˴ϴ�.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "ȸ�� ��ü�� ���߰ų� ��ŷ�Ͻø� ȸ�� ���� �ִ� �����Ͱ� �ռ��� ����� �����Ƿ� ��ü�� ��ŷ�ؼ� �ȵ˴ϴ�.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "�׸��� �⺻���� �κ��� ���� ������ �帮��.", 1.2f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "�׷� �� ��Ź�帳�ϴ�.", 1.2f));
        yield return new WaitForSeconds(2f);
        GameStart();
    } //case 3
    private IEnumerator DeProgress1()   //case 0
    {
        StartCoroutine(DoText(_mainText, "...��ȭ�� ������.", 1.5f));
        _phoneCallingImg.SetActive(false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Progress1());
    }
    private IEnumerator DeProgress2()   //case 1
    {
        StartCoroutine(DoText(_mainText, "��...", 1.5f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "��...��....", 2f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "��¿�� ���� ��", 1f));
        _phoneIdleImg.SetActive(false);
        _phoneCallingImg.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(DoText(_mainText, "(��ȭ�� �����.)", 1f)); //����
    }
    private IEnumerator DeProgress3()
    {
        StartCoroutine(DoText(_mainText, "����� ������ �κ��� ����� TCR(Tactical Combat Robot)�Դϴ�.", 2f));
        yield return new WaitForSeconds(3f);
        StartCoroutine(DoText(_mainText, "���� ���� ȸ��� �˼����°����κ��� ������ �޾� �κ����� �����Ҽ� ���� �����Դϴ�.", 2.5f));
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(DoText(_mainText, "������ �������� ���� �κ����� ȸ�� �����δ� ������ �ʰ� Ȱ��ȭ�� �κ��� ȸ�� ���ο��� �ִ� �����Դϴ�.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "�� �κ����� ��ŷ ���ֽø� �˴ϴ�.", 1f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "ȸ�� ��ü�� ���߰ų� ��ŷ�Ͻø� ȸ�� ���� �ִ� �����Ͱ� �ռ��� ����� �����Ƿ� ��ü�� ��ŷ�ؼ� �ȵ˴ϴ�.", 3f));
        yield return new WaitForSeconds(4f);
        StartCoroutine(DoText(_mainText, "�׸��� �⺻���� �κ��� ���� ������ �帮��.", 1.2f));
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(_mainText, "�׷� �� ��Ź�帳�ϴ�.", 1.2f));
        yield return new WaitForSeconds(2f);
        GameStart();
    }//case 2
    private void DefaulProgress()
    {
        StartCoroutine(DoText(_mainText, "���....���� �̻��ѵ�........", 1f));
        ButtonSet(true,"???","???");
    }
    public void Progressing()
    {
        print("���� ���̽�:" + progress);
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
        print("���� ���̽�:" + progress);
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

    private void ButtonSet(bool value,string yesText = "��", string noText = "�ƴϿ�")
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
