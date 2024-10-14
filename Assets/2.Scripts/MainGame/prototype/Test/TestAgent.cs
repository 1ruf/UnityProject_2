using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAgent : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float FOV;
    private Vector3 enemyDir;
    private Color alpha;
    private Color Nalpha;
    private float dis;
    private void Awake()
    {
        alpha.a = 0;
        Nalpha.a = 1;
    }
    void FixedUpdate()
    {
        dis = Vector2.Distance(enemy.transform.position, transform.position);
        enemyDir = enemy.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, enemyDir,dis , LayerMask.GetMask("wall"));//실제로 작동되는것
        Debug.DrawRay(transform.position, enemyDir,Color.red);//보이는것만
        if (hit.collider || (dis >= FOV))
        {
            enemy.GetComponent<SpriteRenderer>().color = alpha;
        }
        else
        {
            enemy.GetComponent<SpriteRenderer>().color = Nalpha;
        }
    }

}
