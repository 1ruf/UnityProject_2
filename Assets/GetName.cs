using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetName : MonoBehaviour
{
    TextMeshProUGUI NameTxt;

    private void Awake()
    {
        NameTxt = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        NameTxt.text = $"ID : {SaveManager.Instance.GetData<string>((int)Datas.Username)}";
    }

}
