using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject footstep;
    [SerializeField] private int moveSpeed;
    [SerializeField] private float footstepSoundRange;
    private bool footstepCt = false;
    public bool IsAlpha = true;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sr;
    private Vector3 plrPos;

    private void Start()
    {
        plrPos = transform.position;
        _rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Idle());
    }
    IEnumerator Idle()
    {
        while (true)
        {
            int a = Random.Range(0, 4);
            Vector3 dir = Vector3.forward;
            switch (a)
            {
                case 0:
                    dir = Vector3.up;
                    break;
                case 1:
                    dir = Vector3.right;
                    break;
                case 2:
                    dir = Vector3.left;
                    break;
                case 3:
                    dir = Vector3.down;
                    break;
            }
            StartCoroutine(Move(dir));
            yield return new WaitForSeconds(Random.Range(0.2f, 3f));
        }
    }
    private IEnumerator Move(Vector3 moveDir)
    {
        for (int i = 0; i < Random.Range(10,10000); i++)
        {   
            _rb2d.velocity = moveDir.normalized * (moveSpeed/3);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void Update()
    {
        StartCoroutine(PosCheck());
        if (footstepCt == false)
        {
            StartCoroutine(FootstepShow());
        }

    }
    private IEnumerator PosCheck()
    {
        yield return new WaitForSeconds(0.1f);
        plrPos = transform.position;
    }
    private IEnumerator FootstepShow()
    {
        if ((transform.position != plrPos) && IsAlpha)
        {
            _sr = footstep.GetComponent<SpriteRenderer>();
            _sr.DOFade(1, 0);
            footstepCt = true;
            footstep.SetActive(true);
            Vector3 randomPos = new Vector3(transform.position.x + Random.Range(0, footstepSoundRange), transform.position.y + Random.Range(0, footstepSoundRange), transform.position.z);
            footstep.transform.position = randomPos;
            _sr.DOFade(0, 0.8f);
            yield return new WaitForSeconds(0.7f);
            footstepCt = false;
        }
        else
        {
            footstep.SetActive(false);
        }
    }
}