using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Net.Sockets;

public class MenuStart : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject MenuUI;
    private Image background;
    private TMP_Text consoleTxt;

    private void Awake()
    {
        background = GetComponent<Image>();
        consoleTxt = transform.Find("SubTitle").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        FirstSet();
        StartCoroutine(this.StartingProcess());
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            MenuOpen();
        }
    }
    private void FirstSet()
    {
        Color invisible = new Color(0, 0, 0, 0);//투명도가 0인 색 정의
        background.color = invisible;//배경색을 투명한 색으로 바꿈
        consoleTxt.text = null;
        MenuUI.SetActive(false);
    }
    private IEnumerator StartingProcess()
    {
        background.DOFade(1, 1);
        yield return new WaitForSeconds(2f);
        mainCam.DOOrthoSize(6.5f,5f);
        StartCoroutine(DoText(consoleTxt, "starting..\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tchecking for essential elements to start.\t\t\t\t\t\t\t\t\t\nsystemMainKey ?:a1992j3jd82D92jD29djaa92ufFJ929Fj29fh89Zls92873jd82D92jD29dja8811Ad2DPi23jd82D92jD29djM29 \nsystem open requester:" + NetworkHelper.GetMyIpAddress() + NetworkHelper.GetMyAllIPAddress() + "\n\tmainSystem.b1HDGk.connect = true\n\tmainSystem.j5AUsJ.connect = true\n\tmainSystem.oaP2Fs.connect = true\nSERVER/ConnectedDevice:Serching\nSERVER/ConnectedDevice:mainOLH.Head:CanDestroy/checking:TRUE\nSERVER/ConnectedDevice:mainOLH.Head:Waiting/checking:TRUE\nSERVER/ConnectedDevice:mainOOL.Root/checking:TRUE\n\t\t\t\t\t\t\nDeviceFinding:you need to send from \"main OOL HU.reader.straperSting\"\n\tDEVICE/ClientAssembly:System.Collections.Specialized/ProcessDialog:dismath\n\tDEVICE/ClientAssembly:System.Collections.Concurrent/ProcessDialog:dismath)_\n\tDEVICE/ClientAssembly:System.Xml.Serialization/ProcessDialog:math)_\nPress any key to continue..", 3f));
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
    private void MenuOpen()
    {
        gameObject.SetActive(false);
        MenuUI.SetActive(true);
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
