using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour,IPointerEnterHandler
{
    [SerializeField] private AudioSource _audio;
    public void BtnSelected()
    {
        _audio.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        BtnSelected();
    }
}
