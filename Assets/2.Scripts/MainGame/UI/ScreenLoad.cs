using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;

public class ScreenLoad : MonoBehaviour
{
    [Header("Information")]
    [SerializeField] private int nowStage;
    [Header("objects")]
    [SerializeField] private GameObject nosignalPanel;
    [SerializeField] private GameObject map;
    [SerializeField] private Image loadingBar_Main;
    [SerializeField] private Image loadingBar_BG;
    [SerializeField] private TMP_Text loadingTitle, mainTitle;


    private int a;
    private void Awake()
    {
        nosignalPanel.SetActive(false);
    }
    private void Start()
    {
        SetStage();
    }
    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            a += 1;
            PlayerPrefs.SetInt("NowSavedStage",a);
            print(PlayerPrefs.GetInt("NowSavedStage"));
        }
    }
    private void SetStage()
    {
        EZSceneLoad(CheckStage());
    }
    private bool CheckStage()
    {
        if (nowStage <= PlayerPrefs.GetInt("NowSavedStage"))
            return true;
        else   
            return false;    
    }

    public void EZSceneLoad(bool canActive)
    {
        if (canActive)
        {
            StartCoroutine(load());

        }
        else
        {
            mainTitle.text = name + ": NO SIGNAL";
            nosignalPanel.SetActive(true);
        }
    }
    private IEnumerator load()
    {
        string[] nowState = mainTitle.text.Split(':');
        string name = nowState[0];
        mainTitle.text = name + ": CONNECTING..";

        loadingBar_Main.fillAmount = 0;
        float randFill = UnityEngine.Random.Range(0.07f, 0.15f);
        float fillAmt = 0;
        while (true)
        {
            loadingBar_Main.fillAmount = fillAmt / 1;
            yield return new WaitForSeconds(0.1f);
            if (fillAmt > 1)
            {
                break;
            }
            fillAmt += randFill;
        }
        yield return new WaitForSeconds(0.35f);
        loadingBar_BG.DOFade(0, 1f);
        loadingBar_Main.DOFade(0, 1f);
        loadingTitle.DOFade(0, 1f);
        GameObject Smap = Instantiate(map);
        Smap.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        mainTitle.text = name + ": CONNECTED";
        Smap.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Smap.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Smap.SetActive(true);
    }
}
