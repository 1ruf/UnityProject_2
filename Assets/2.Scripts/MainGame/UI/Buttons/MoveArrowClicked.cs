using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using URPGlitch.Runtime.DigitalGlitch;
using URPGlitch.Runtime.AnalogGlitch;

public class MoveArrowClicked : MonoBehaviour /////////////////코드를 에전에 짠거랑 섞었기 때문에 못알아보니까 주석으로 설명해드림
{
    [SerializeField] private ScreenLoad EZ, S1, S2, S3;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private Image arrowL, arrowR, tabBtn;
    [SerializeField] private Button EnterBtn;
    [SerializeField] private TMP_Text zoomBtnTxt;
    [SerializeField] private int maxArea ,minArea, nowSector;
    [SerializeField] private float camMoveSpeed;
    [SerializeField] private Volume _volume;

    private DigitalGlitchVolume _digitalGt;
    private AnalogGlitchVolume _analogGt;
    private GameObject buttonUI;
    private Vector3 nowCamPos;
    private Vector3 localCamPos_EZ = new Vector3(0, 0, -10), localCamPos_S1 = new Vector3(17.8f, 0, -10), localCamPos_S2 = new Vector3(0, -9.65f, -10), localCamPos_S3 = new Vector3(17.8f, -9.65f, -10);
    private bool IsCool,IsTab,IsTabCool,canEnter,canClick = true;



    private void Awake()
    {
        buttonUI = transform.Find("ButtonsUI").gameObject; //버튼 UI 게임오브젝트 가져오기
    }
    private void Start()
    {
        ArrowSet();//함수 호출
    }
    private void OnEnable()
    {
        buttonUI.SetActive(false);//버튼 UI 일시적으로 비활성화
        IsTabCool = true;
        mainCam.GetComponent<Camera>().DOOrthoSize(10f, 1f).OnComplete(() => //DoTWeen에 카메라 사이즈 설정하는거 완료되면
        {
            IsTabCool = false;
            buttonUI.SetActive(true);//버튼 UI 켜기
            CheckTab();//함수 호출
        });
        IsTab = true;

    }
    private void Update()
    {
        IsCool = IsTab;
        if (canClick == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LeftClick();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                RightClick();
            }
            else if (Input.GetKeyDown(KeyCode.Tab))
            {
                SectorClick();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                EnterGame();
            }
        }
    }
    public void EnterGame()
    {
        if (IsTab == false && canEnter == true)
        {
            StartCoroutine(EnterStage());//코루틴 함수 호출
            EnterBtn.interactable = true;//시작 버튼 활성
        }
        else
        {
            EnterBtn.interactable = false;//시작 버튼 비활성
        }
    }
    private IEnumerator EnterStage()
    {
        canClick = false;
        buttonUI.SetActive(false);
        CamSet(nowSector);//함수에 nowSector 보내면서 호출
        mainCam.GetComponent<Camera>().DOOrthoSize(0.3f, 1.5f).SetEase(Ease.InBack); //DoTWeen 카메라 줌 인
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(GlitchChange());
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage" + (nowSector + 1).ToString());
    }

    public void RightClick()
    {
        if (IsCool == false)
        {
            if (nowSector < maxArea)
            {
                nowSector++;
                RightMove();
                StartCoroutine(Cooler(1f));
            }
        }
    }
    public void LeftClick()
    {
        if (IsCool == false)
        {
            if (nowSector > minArea)
            {
                nowSector--;
                LeftMove();
                StartCoroutine(Cooler(1f));
            }
        }
    }
    public void SectorClick()
    {
        MapPopUp();
        CheckTab();
        CheckMap();
    }
    private IEnumerator Cooler(float coolTime)
    {
        IsCool = true;
        yield return new WaitForSeconds(coolTime);
        IsCool = false;
    }
    private void RightMove()
    {
        arrowL.DOFade(1f, 0.1f);
        CamSet(nowSector);
        //mainCam.transform.DOMoveX((mainCam.transform.position.x + moveVal), 0.7f);
        if (nowSector >= maxArea)
        {
            arrowR.DOFade(0.3f, 0.1f);
        }
    }
    private void LeftMove()
    {
        arrowR.DOFade(1f, 0.1f);
        CamSet(nowSector);
        //mainCam.transform.DOMoveX((mainCam.transform.position.x - moveVal), 0.7f);
        if (nowSector <= minArea)
        {
            arrowL.DOFade(0.3f, 0.1f);
        }
    }
    private void CheckMap()
    {
        if (Check(nowSector))
        {
            EnterBtn.interactable = true;
            canEnter = true;
        }
        else
        {
            EnterBtn.interactable = false;
            canEnter = false;
        }
    }
    private bool Check(int Sector)
    {
        if (Sector == 3)
        {
            return SaveManager.Instance.CheckData((int)Datas.Stage4);
        }
        else if (Sector == 2)
        {
            return SaveManager.Instance.CheckData((int)Datas.Stage3);
        }
        else if (Sector == 1)
        {
            return SaveManager.Instance.CheckData((int)Datas.Stage2);
        }
        else if (Sector == 0)
        {
            return SaveManager.Instance.CheckData((int)Datas.Stage1);
        }
        else return true;
    }
    private void CheckTab()
    {
        if (IsTab == false)
        {
            EnterBtn.interactable = true;
        }
        else
        {
            EnterBtn.interactable = false;
        }
    }
    private void MapPopUp()
    {
        //CheckTab();
        nowCamPos = mainCam.transform.position;
        if (!IsTab && !IsTabCool)
        {
            StartCoroutine(TabCool());
            IsCool = true;
            IsTab = true;
            arrowL.DOFade(0.3f, 0.1f);
            arrowR.DOFade(0.3f, 0.1f);
            zoomBtnTxt.text = "ZOOM IN\n(TAB)";
            mainCam.transform.DOMove(new Vector3(8.9f, -5, -10),1);
            mainCam.GetComponent<Camera>().DOOrthoSize(10f, 1f);
            ArrowSet();
        }
        else if (IsTab && !IsTabCool)
        {
            StartCoroutine(TabCool());
            IsCool = false;
            IsTab = false;
            arrowL.DOFade(1f, 0.1f);
            arrowR.DOFade(1f, 0.1f);
            zoomBtnTxt.text = "ZOOM OUT\n(TAB)";
            mainCam.GetComponent<Camera>().DOOrthoSize(5f, 1f);
            CamSet(nowSector);
            ArrowSet();
        }
    }
    private void CamSet(int sector)
    {
        CheckTab();
        CheckMap();
        Transform camTP = mainCam.transform;
        switch (sector)
        {
            case 0:
                camTP.DOMove(localCamPos_EZ, camMoveSpeed);
                break;
            case 1:
                camTP.DOMove(localCamPos_S1, camMoveSpeed);
                break;
            case 2:
                camTP.DOMove(localCamPos_S2, camMoveSpeed);
                break;
            case 3:
                camTP.DOMove(localCamPos_S3, camMoveSpeed);
                break;
        }
    }
    private void ArrowSet()
    {
        if (nowSector <= minArea)
        {
            arrowL.DOFade(0.3f, 0.1f);
        }
        else if (nowSector >= maxArea)
        {
            arrowR.DOFade(0.3f, 0.1f);
        }
    }
    private IEnumerator TabCool()
    { 
        IsTabCool = true;
        float nowfillAmt = 0f;
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.02f);
            nowfillAmt += 0.02f;
            tabBtn.fillAmount = nowfillAmt / 1;
        }
        IsTabCool = false;
    }
    private IEnumerator GlitchChange()
    {
        DigitalGlitchVolume _digitalGlitch;
        AnalogGlitchVolume _analogGlitch;
        if (_volume.profile.TryGet<DigitalGlitchVolume>(out _digitalGlitch))
        {
            _volume.profile.TryGet<AnalogGlitchVolume>(out _analogGlitch);
            _digitalGt = _digitalGlitch;
            _analogGt = _analogGlitch;
            float value = 0.0f;
            while(true)
            {
                if (_digitalGt.intensity.value >= 1)
                {
                    break;
                }
                value += 0.05f;
                _analogGt.scanLineJitter.value = value;
                _digitalGt.intensity.value = value;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
