using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private AudioMixerGroup _bgm;

    private bool IsOpen;
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
        //for (float i = 0f; i < 20f; i++)
        //{
        //    pitchVal -= i / 20f;
            
        //}
    }


    public void Continue()
    {
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
