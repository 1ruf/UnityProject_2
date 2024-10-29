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


    public void CoolTimeReSet() // ��ŷ ��ų ����ϸ� ȣ�� ( ������ų�� ��Ÿ���� �ʱ�ȭ�Ͽ� ��ŷ �� �ٷ� ��ų ��� ����
    {
        if (_coolCoroutine != null) StopCoroutine(_coolCoroutine);
        CanSkill = true;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);
    }


    private IEnumerator SkillCool() // ��ų UI ���� �� ó�� ���̰���, ��ų ��� �Ұ��� ���·� ����� ��Ÿ�� �Ŀ� ���󺹱�
    {
        CanSkill = false;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0.5f); 
        yield return new WaitForSeconds(_coolTime);
        CanSkill = true;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);
    }


}
