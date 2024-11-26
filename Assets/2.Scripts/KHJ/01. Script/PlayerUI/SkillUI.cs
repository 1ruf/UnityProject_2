using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void VisibleChange(bool value)
    {
        Color clr = _renderer.color;
        _renderer.color = value ? Visible(clr) : Invisible(clr);
    }

    public void SetAlpha(int value) //max = 255
    {
        if (value > 255) return;
        Color clr = _renderer.color;
        SetVisible(clr, value);
    }







    //-----------------------------------------------------------------------------
    /// <summary>
    /// clr��� �̸��� color �� ����, clr.r,g,b�� �޾ƿͼ� �״�� ������
    /// alpha���� 0 �Ǵ� 255�� ����
    /// </summary>
    /// <param name="clr"></param>
    /// <returns></returns>
    private Color Invisible(Color clr)
    {
        return new Color(clr.r, clr.g, clr.b, 0);
    }
    private Color Visible(Color clr)
    {
        return new Color(clr.r, clr.g, clr.b, 255);
    }
    private Color SetVisible(Color clr,int alpha)
    {
        return new Color(clr.r, clr.g, clr.b, alpha);
    }
    //-----------------------------------------------------------------------------
}
