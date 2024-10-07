using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecter : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    [SerializeField] private EnemyMovement enemyScript;
    [SerializeField] private float FOV;
    [SerializeField] private LayerMask targetMask;
    private GameObject enemy;
    private GameObject targetEnemy;
    private Vector3 enemyDir;
    private Color alpha, Nalpha;
    private float dis, maxAngle = 50f;
    private bool isVisible;
    private void Awake()
    {
        alpha.a = 0;
        Nalpha.a = 1;
    }
    private void Update()
    {
        CheckVisibility();
    }
    void FixedUpdate()
    {
        Detect();
        dis = Vector2.Distance(enemy.transform.position, transform.position); //적과 자신의 거리 구해서 dis 에 넣음
        enemyDir = enemy.transform.position - transform.position; 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, enemyDir, dis, LayerMask.GetMask("wall"));//실제로 작동되는것
        Debug.DrawRay(transform.position, enemyDir, Color.red);//보이는것만
        DetectCollider(hit);
    }
    private void DetectCollider(RaycastHit2D hit2D)
    {
        if (hit2D.collider || (dis >= FOV) || !isVisible)
        {
            enemy.GetComponent<SpriteRenderer>().color = alpha;
            enemyScript.IsAlpha = true;
        }
        else
        {
            enemy.GetComponent<SpriteRenderer>().color = Nalpha;
            enemyScript.IsAlpha = false;
        }
    }
    void CheckVisibility()
    {
        Vector3 directionToTarget = enemy.transform.position - transform.position;
        directionToTarget.Normalize();

        Vector3 rotatedDirection = Quaternion.Euler(0, 0, 90) * transform.right;

        float angle = Vector3.Angle(rotatedDirection, directionToTarget);

        if (angle <= maxAngle)
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }
    }
    private void Detect()
    {
        targetEnemy = GameObject.Find("Enemy");
        enemy = targetEnemy;
    }
}
