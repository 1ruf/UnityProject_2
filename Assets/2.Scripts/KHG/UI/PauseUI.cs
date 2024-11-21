using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI, _subTitle;
    [SerializeField] private TextMeshProUGUI _exitBtnTxt;

    private bool IsOpen;
    private int askCount;
    private void Awake()
    {
        _subTitle.SetActive(false);
        _pauseUI.SetActive(false);
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (IsOpen == true)
            {
                IsOpen = false;
                Continue();
            }
            else
            {
                IsOpen = true;
                Pause();
            }
        }
    }
    private void Pause()
    {
        //float pitchVal = 1;
        Time.timeScale = 0;
        _pauseUI.SetActive(true);
        askCount = 0;
        //for (float i = 0f; i < 20f; i++)
        //{
        //    pitchVal -= i / 20f;

        //}
    }


    public void Continue()
    {
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
        ResetUI();
    }
    public void Exit()
    {
        switch (askCount)
        {
            case 0:
                ReaskExit();
                askCount++;
                break;
            case 1:
                Time.timeScale = 1;
                SceneManager.LoadScene("MenuScene");
                break;
        }
    }
    private void ResetUI()
    {
        _subTitle.SetActive(false);
        _exitBtnTxt.color = Color.white;
    }
    private void ReaskExit()
    {
        _exitBtnTxt.color = Color.red;
        _subTitle.SetActive(true);
    }
}
