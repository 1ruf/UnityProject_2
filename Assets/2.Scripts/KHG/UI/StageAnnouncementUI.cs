using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class StageAnnouncementUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _announceTxt;
    private RectTransform _rTransform;
    private SpriteRenderer _renderer;

    [Header("Setting")]
    [SerializeField] private string _text;
    [SerializeField] private float _disapearTime;

    private void Awake()
    {
        _rTransform = GetComponent<RectTransform>();
        _rTransform.localScale = new Vector3(0, 1, 1);
    }
    private void OnEnable()
    {
        gameObject.SetActive(true);
        StartCoroutine(Visible());
    }
    private IEnumerator Visible()
    {
        yield return new WaitForSeconds(1f);
        _announceTxt.text = _text;
        _rTransform.DOScaleX(1, 0.2f);
        yield return new WaitForSeconds(_disapearTime);
        _rTransform.DOScaleX(0, 0.2f).OnComplete(()=>gameObject.SetActive(false));
    }
}
