using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private float _coolTime = 5f;

    public bool CanSkill { get; private set; } = true;
    private Image _image;

    private Coroutine _coolCoroutine;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        
    }

    public void Cool()
    {
        _coolCoroutine = StartCoroutine(SkillCool());
    }


    public void CoolTimeReSet() // 해킹 스킬 사용하면 호출 ( 고유스킬의 쿨타임을 초기화하여 해킹 후 바로 스킬 사용 가능
    {
        if (_coolCoroutine != null) StopCoroutine(_coolCoroutine);
        CanSkill = true;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);
    }


    private IEnumerator SkillCool() // 스킬 UI 꺼진 것 처럼 보이게함, 스킬 사용 불가능 상태로 만들고 쿨타임 후에 원상복구
    {
        CanSkill = false;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0.5f); 
        yield return new WaitForSeconds(_coolTime);
        CanSkill = true;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);
    }


}
