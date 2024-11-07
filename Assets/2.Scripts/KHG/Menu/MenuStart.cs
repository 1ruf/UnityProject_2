using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Net.Sockets;

public class MenuStart : MonoBehaviour
{
    [SerializeField] private MenuBGMManager _menuManager;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject MenuUI, button;
    private Image background;
    private TMP_Text consoleTxt;
    private int holdTime;
    private bool canClick = true, requestActive = false;
    private void Awake()
    {
        background = GetComponent<Image>();
        consoleTxt = transform.Find("SubTitle").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        StartCoroutine(PleaseStandBy());
        StartCoroutine(this.StartingProcess());
    }
    private void Update()
    {
        
        if (requestActive)
        {
            if (Keyboard.current.yKey.wasPressedThisFrame)
            {
                button.SetActive(true);
                StartCoroutine(Positive());
            }
            else if (Keyboard.current.nKey.wasPressedThisFrame)
            {
                button.SetActive(true);
                StartCoroutine(Negative());
            }
        }
        else if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            MenuOpen();
            BGMPlay();
        }
    }
    public void GrantBtnClicked()
    {
        StartCoroutine(Positive());
    }
    public void DenyBtnClicked()
    {
        StartCoroutine(Negative());
    }
    private IEnumerator Positive()
    {
        transform.Find("Buttons").gameObject.SetActive(false);
        AddText("\naccessing...");
        yield return new WaitForSeconds(1f);
        BGMPlay();
        AddText("\nconnected.");
        MenuOpen();
    }
    private void AddText(string text)
    {
        consoleTxt.text += text;
    }
    private IEnumerator Negative()
    {
        transform.Find("Buttons").gameObject.SetActive(false);
        AddText("\naccess denied.");
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
    private IEnumerator PleaseStandBy() 
    {
        MenuUI.transform.Find("StartMenu").gameObject.SetActive(false);
        MenuUI.transform.Find("MainMenu").gameObject.SetActive(false);
        holdTime = UnityEngine.Random.Range(1, 4);
        for (int i = 0; i < holdTime; i++)
        {
            consoleTxt.text = "_";
            yield return new WaitForSeconds(0.5f);
            consoleTxt.text = " ";
            yield return new WaitForSeconds(0.5f);

        }
        FirstSet();
    }
    private void FirstSet()
    {
        Color invisible = new Color(0, 0, 0, 0);//투명도가 0인 색 정의
        background.color = invisible;//배경색을 투명한 색으로 바꿈
        consoleTxt.text = null;
    }
    private IEnumerator StartingProcess()
    {
        background.DOFade(1, 1);
        yield return new WaitForSeconds(holdTime);
        mainCam.DOOrthoSize(6.5f, 7f);
        StartCoroutine(DoText(consoleTxt, "starting..\nchecking for essential elements to start.\nsystemMainKey?:a1992j3jd82D, requesterPCIP:" + NetworkHelper.GetMyIpAddress() + NetworkHelper.GetMyAllIPAddress() + "_", 1f));
        yield return new WaitForSeconds(1.5f);
        requestActive = true;
        AddText("\nare you sure to connect?[ Y / N ])");
        yield return new WaitForSeconds(1f);
        print(requestActive);
        if (requestActive == true)
        {
            button.SetActive(true);
        }
        //StartCoroutine(DoText(consoleTxt, "starting..\nchecking for essential elements to start.\t\t\t\t\t\t\t\t\t\nsystemMainKey ?:a1992j3jd82D92jD29djaa92ufFJ929Fj29fh89Zls92873jd82D92jD29dja8811Ad2DPi23jd82D92jD29djM29 \nsystem open requester:" + NetworkHelper.GetMyIpAddress() + NetworkHelper.GetMyAllIPAddress() + "\n\tmainSystem.b1HDGk.connect = true\n\tmainSystem.j5AUsJ.connect = true\n\tmainSystem.oaP2Fs.connect = true\nSERVER/ConnectedDevice:Serching\nSERVER/ConnectedDevice:mainOLH.Head:CanDestroy/checking:TRUE\nSERVER/ConnectedDevice:mainOLH.Head:Waiting/checking:TRUE\nSERVER/ConnectedDevice:mainOOL.Root/checking:TRUE\n\t\t\t\t\t\t\nDeviceFinding:you need to send from \"main OOL HU.reader.straperSting\"\n\tDEVICE/ClientAssembly:System.Collections.Specialized/ProcessDialog:dismath\n\tDEVICE/ClientAssembly:System.Collections.Concurrent/ProcessDialog:dismath)_\n\tDEVICE/ClientAssembly:System.Xml.Serialization/ProcessDialog:math)_\nWELCOME_BACK\nPress any key to continue..", 0));
        //yield return new WaitForSeconds(5.5f);
    }
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
    private void BGMPlay()
    {
        _menuManager.PlayBGMWithPitch(_menuManager._audio,0.9f, 1f, true);
        print("played");
    }
    private void MenuOpen()
    {
        gameObject.SetActive(false);
        MenuUI.SetActive(true);
        MenuUI.transform.Find("MainMenu").gameObject.SetActive(true);
        mainCam.orthographicSize = 6.5f;
        DOTween.KillAll();
    }
    public static class NetworkHelper
    {
        public static string GetMyIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("error");
        }
        public static string GetMyAllIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList[0].ToString();
        }

        public static bool IsLocalHost(IPEndPoint ep)
        {
            return ep.Address.ToString().Equals(GetMyIpAddress());
        }

    }
}
