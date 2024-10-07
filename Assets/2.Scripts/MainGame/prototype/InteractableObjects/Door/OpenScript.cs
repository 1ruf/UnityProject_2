using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; //import


public class OpenScript : MonoBehaviour
{
    [SerializeField] private GameObject doorPanel;
    [SerializeField] private Image interract;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private float detectableRadius;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int targetAngle;
    private float currentTime = 0;
    private bool IsOpen = false;
    private bool IsCool = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Detect();
        }
    }

    private void Detect()
    {
        Collider2D collision = Physics2D.OverlapCircle(transform.position, detectableRadius, targetMask);
        print(IsCool);
        if (collision && (IsCool == false))
        {
            if (IsOpen)
            {
                IsOpen = false;
                StartCoroutine(CoolTime());
                Close(collision.gameObject);
            }
            else
            {
                IsOpen = true;
                StartCoroutine(CoolTime());
                Open(collision.gameObject);
            }
        }
    }
    private void Close(GameObject plr)
    {
        doorPanel.transform.DORotate(new Vector3(0,0,0), 1).SetEase(Ease.OutCubic);
    }
    private void Open(GameObject plr)
    {
        if ((transform.position.y - plr.transform.position.y) < 0)
        {
            doorPanel.transform.DORotate(new Vector3(0, 0,-105), 1).SetEase(Ease.OutCubic);
        }
        else
        {
            doorPanel.transform.DORotate(new Vector3(0, 0, 105), 1).SetEase(Ease.OutCubic);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectableRadius);
    }
    private IEnumerator CoolTime()
    {
        IsCool = true;
        yield return new WaitForSeconds(1f);
        IsCool = false;
    }
}
