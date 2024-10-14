using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunUI : MonoBehaviour
{ 
    [SerializeField] private Gun gunScript;

    [SerializeField] private TMP_Text gunNameTxt;
    [SerializeField] private TMP_Text ammoTxt;

    private void Start()
    {
        SetUIText("nothing",0,0);
    }
    public void SetUIText(string gunName, int nowAmmo, int maxAmmo)
    {
        if (gunName == null)
            return;
        gunNameTxt.text = gunName;
        ammoTxt.text = $"{nowAmmo} / {maxAmmo}";
    }
}
