using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingSkill : MonoBehaviour
{
    [SerializeField] private LayerMask _ememy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D ray = Physics2D.Raycast(mousePos, transform.forward, 20);
            print(1);
            if (ray.collider != null)
            {
                PlayerChange(ray.transform);
            }
        }
    }

    private void PlayerChange(Transform enemy)
    {
        PlayerMove.Instance._player.GetComponent<SpriteRenderer>().color = Color.red;
        PlayerMove.Instance._player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        enemy.GetComponent<SpriteRenderer>().color = Color.green;
        PlayerMove.Instance._player = enemy;
    }
}
