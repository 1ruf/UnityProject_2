using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetName : MonoBehaviour
{
    TextMeshPro NameTxt;

    private void Awake()
    {
        NameTxt = GetComponent<TextMeshPro>();
    }
    private void Start()
    {
        NameTxt.text += SaveManager.Instance.GetData<string>(0);
    }

}
