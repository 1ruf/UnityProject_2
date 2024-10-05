using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class E : MonoBehaviour
{
    [SerializeField] private GameObject interactLocation;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private float detectableRadius;
    private Image me;
    private void Start()
    {
        me = GetComponent<Image>();
    }
    private void Update()
    {
        Detect();
        transform.position = interactLocation.transform.position;
    }
    private void Detect()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, detectableRadius, targetMask);
        if (collision)
        {
            me.DOFade(1, 0.2f);
        }
        else
        {
            me.DOFade(0, 0.4f);
        }
    }
}
