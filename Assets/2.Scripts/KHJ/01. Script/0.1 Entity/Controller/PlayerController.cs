using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public PlayerController Instance;

    [SerializeField] private Entity _currentEntity;

    [SerializeField] private InputReader InputCompo;
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;

    private void Awake()
    {
        if (Instance)
            Destroy(this);
        else
            Instance = this;

    }
    private void Start()
    {
        Enter();
        _currentEntity.GetComponent<EnemyControl>().enabled = false;
        _currentEntity.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.17f);
        _cinemachineCamera.Follow = _currentEntity.transform;
        _currentEntity.transform.tag = "Player";
    }
    private void HandleLeftMousePressed()
    {
        _currentEntity.Attack();
    }

    private void HandleTabKey()
    {
        Harking();
    }
    private void HandleMovement(Vector2 vector)
    {
        _currentEntity.SetMoveDire(vector);
    }
    public void Enter()
    {
        InputCompo.OnLeftMouse += HandleLeftMousePressed;
        InputCompo.OnMove += HandleMovement;
        InputCompo.OnTabKey += HandleTabKey;
    }
    public void Exit()
    {
        InputCompo.OnLeftMouse -= HandleLeftMousePressed;
        InputCompo.OnMove -= HandleMovement;
        InputCompo.OnTabKey -= HandleTabKey;
    }
    private void Harking()
    {


        Vector2 mousePos = GameManager.Instance.GetMousePos();
        RaycastHit2D[] ray2d = Physics2D.RaycastAll(mousePos, mousePos, 0);
        if (ray2d == null) return;

        Entity newEntity = null;
        foreach (RaycastHit2D item in ray2d)
        {
            if (item.transform.GetComponent<Entity>())
            {
                newEntity = item.transform.GetComponent<Entity>();
            }
        }

        newEntity.tag = "Player";
        _currentEntity.tag = "Untagged";
        newEntity.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.17f);
        _currentEntity.TakeDamage(int.MaxValue);


        _cinemachineCamera.Follow = newEntity.transform;

        newEntity.GetComponent<EnemyControl>().enabled = false;
        _currentEntity.GetComponent<EnemyControl>().enabled = true;

        ChangeCurrentEntity(newEntity);
    }

    private void ChangeCurrentEntity(Entity newEntity)
    {
        Exit();
        _currentEntity = newEntity;
        Enter();
    }
}
