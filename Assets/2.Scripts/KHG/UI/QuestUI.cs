using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using DG.Tweening;
using TMPro;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private RectTransform _arrowImg;
    [SerializeField] private RectTransform _missionUI;

    [SerializeField] private TextMeshProUGUI _text;

    private bool isOpend;
    private void OnEnable()
    {
        SetText("엘리베이터를 찾아 \n다음 층으로 가십시오.");
        Open();
    }

    private void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            if (isOpend == true)
            {
                isOpend = false;
                Close();
            }
            else
            {
                isOpend = true;
                Open();
            }
        }
    }

    public void Clicked(bool value)
    {
        if (value == true) Open();
        else Close();
    }
    private void Open()
    {
        _missionUI.DOScaleX(1f, 0.3f).SetEase(Ease.OutExpo);
        _arrowImg.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    private void Close()
    {
        _missionUI.DOScaleX(0f, 0.3f).SetEase(Ease.InExpo);
        _arrowImg.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }


    public void SetText(string text)
    {
        _text.text = text;
        _text.DOColor(Color.yellow, 0.3f).OnComplete(() => _text.DOColor(Color.white, 0.3f));
        _text.GetComponent<RectTransform>().DOScale(1.2f, 0.3f).OnComplete(() => _text.GetComponent<RectTransform>().DOScale(1f, 0.3f));
    }
}
