using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MenuStart : MonoBehaviour
{
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
    }
    private IEnumerator StartingProcess()
    {
        background.DOFade(1, 1);
        yield return new WaitForSeconds(2f);
        StartCoroutine(DoText(consoleTxt, "starting\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)"
            + "\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\n+ CategoryInfo\t: ParserError: (:) [], ParentContainsErrorRecordException + FullyQualifiedErrorId : ExpectedExpression\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\nNullReferenceException: Object reference not set to an instance of an object\nMenuStart.FirstSet()(at Assets / 2.Scripts / KHG / MenuStart.cs:26)\nMenuStart.Start()(at Assets / 2.Scripts / KHG / MenuStart.cs:20)\n\n\npress any key to start.", 0.01f));
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
    }
}
