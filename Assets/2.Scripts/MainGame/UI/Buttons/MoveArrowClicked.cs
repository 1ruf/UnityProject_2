using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MoveArrowClicked : MonoBehaviour
{
    [SerializeField] private ScreenLoad EZ, S1, S2, S3;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private Image arrowL, arrowR, tabBtn;
    [SerializeField] private Button EnterBtn;
    [SerializeField] private TMP_Text zoomBtnTxt;
    [SerializeField] private int maxArea ,minArea, nowSector;
    [SerializeField] private float camMoveSpeed;
    [SerializeField] private Volume _volume;


    private GameObject buttonUI;
    private Camera cam = new Camera();
    private Vector3 nowCamPos;
    private Vector3 localCamPos_EZ = new Vector3(0, 0, -10), localCamPos_S1 = new Vector3(17.8f, 0, -10), localCamPos_S2 = new Vector3(0, -9.65f, -10), localCamPos_S3 = new Vector3(17.8f, -9.65f, -10);
    private bool IsCool,IsTab,IsTabCool;
    private bool canDispatch;


    Bloom _bloom;


    private void Awake()
    {
        buttonUI = transform.Find("ButtonsUI").gameObject;
    }
    private void Start()
    {
        ArrowSet();
    }
    private void OnEnable()
    {
        buttonUI.SetActive(false);
        IsTabCool = true;
        mainCam.GetComponent<Camera>().DOOrthoSize(10f, 1f).OnComplete(() =>
        {
            IsTabCool = false;
            buttonUI.SetActive(true);
            CheckTab();
        });
        IsTab = true;
    }
    private void Update()
    {
        IsCool = IsTab;
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
    public void EnterGame()
    {
        if (IsTab == false)
        {
            StartCoroutine(EnterStage());
            EnterBtn.interactable = true;
        }
        else
        {
            EnterBtn.interactable = false;
        }
    }
    private IEnumerator EnterStage()
    {
        buttonUI.SetActive(false);
        CamSet(nowSector);
        mainCam.GetComponent<Camera>().DOOrthoSize(0, 1.5f).SetEase(Ease.InBack);


        Bloom bV;
        if (_volume.profile.TryGet<Bloom>(out bV))
        {
            _bloom = bV;
        }
        _bloom.active = true;

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Stage" + (nowSector + 1).ToString());
    }

    public void RightClick()
    {
        print("Rclicked");
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
        CheckTab();
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
}
