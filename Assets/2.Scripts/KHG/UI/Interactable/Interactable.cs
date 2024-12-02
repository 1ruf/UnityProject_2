using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 3f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Image[] _InteractUI;
    [SerializeField] private TextMeshProUGUI[] _InteractUI_TMP;
    private bool _isInRange = false; 

    public UnityEvent OnInteracted;



    private Entity _plrData;


    private void Update()
    {
        HandleInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _plrData = collision.GetComponent<Entity>();
            _isInRange = true;
            ShowInteractUI(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & interactableLayer) != 0)
        {
            _isInRange = false;
            ShowInteractUI(false);
        }
    }

    private void ShowInteractUI(bool show)
    {
        if (show)
        {
            foreach (var UI in _InteractUI)
            {
                UI.DOFade(1f, 0.5f);
            }
            foreach (var UI in _InteractUI_TMP)
            {
                UI.DOFade(1f, 0.5f);
            }
        }
        else
        {
            foreach (var UI in _InteractUI)
            {
                UI.DOFade(0f, 0.5f);
            }
            foreach (var UI in _InteractUI_TMP)
            {
                UI.DOFade(0f, 0.5f);
            }
        }
    }

    private void HandleInput()
    {
        if (_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }
    }

    private void Pressed()
    {
        print("캐릭터 저장됨"+ _plrData.Data.name);
        SaveManager.Instance.SetCharater(PlayerTyper(_plrData.Data.name));
        OnInteracted?.Invoke();
        //gameObject.SetActive(false);
    }

    private Datas PlayerTyper(string name)
    {
        switch (name)
        {
            case "Orc1":
                return Datas.Char_orc1;
            case "Orc2":
                return Datas.Char_orc2;
            case "Orc3":
                return Datas.Char_orc3;
            case "Lucy":
                return Datas.Char_orc3;
            case "Skel":
                return Datas.Char_Skel;
            default:
                return Datas.Char_orc1;
        }
    }
}
