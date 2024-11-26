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

    float _attackCool = 0.5f;
    private bool _canAttack = true;

    [SerializeField] private float _usedGauge = 30f;
    [SerializeField] private float _maxGauge = 100f;
    [SerializeField] private float _reproduction = 0.5f;
    private float _currentGauge;

    [SerializeField] private float _harKingCoolTime = 2f;
    private bool _canHarking = true;

    private Vector2 _inputVector;

    private void Awake()
    {
        if (Instance)
            Destroy(this);
        else
            Instance = this;
        _currentGauge = _maxGauge;
    }
    private void Start()
    {
        Enter();
        StartCoroutine(ReproductionGauge());
        _currentEntity.TryGetAddComponenet<EnemyControl>().enabled = false;
        _currentEntity.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.17f);
        _cinemachineCamera.Follow = _currentEntity.transform;
        _currentEntity.transform.tag = "Player";
        Bar.Instance.BarValueChange(BarSliderType.Energy, _currentGauge, _maxGauge);
        //_currentEntity.AnimCompo.Animator.speed = 3f;
        _currentEntity.SetHPUI();
    }


    private void Update()
    {
        _currentEntity.SetMoveDire(_inputVector);
    }

    private void HandleLeftMousePressed()
    {
        if (!_canAttack || !_currentEntity.StateCompo.StateCheck(_currentEntity.CurrentState)) return;
        StartCoroutine(CoolTimeCorotine(_canAttack, _attackCool));
        _currentEntity.Attack();
    }

    IEnumerator CoolTimeCorotine(bool can, float coolTime)
    {
        can = false;
        yield return new WaitForSeconds(coolTime);
        can = true;
    }

    

    private void HandleTabKey()
    {
        StartCoroutine(CoolTimeCorotine(_canHarking ,_harKingCoolTime));

        Vector2 mousePos = GameManager.Instance.GetMousePos();

        if (Vector2.Distance(_currentEntity.transform.position, mousePos) > 6) return;

        RaycastHit2D[] ray2d = Physics2D.RaycastAll(mousePos, mousePos, 0);
        if (ray2d == null) return;

        Entity newEntity = null;
        foreach (RaycastHit2D item in ray2d)
        {
            if (item.transform.GetComponent<Entity>() && item.transform.gameObject.tag == "Enemy")
            {
                newEntity = item.transform.GetComponent<Entity>();
                Harking(newEntity);
                break;
            }
        }
    }
    private void HandleMovement(Vector2 vector)
    {
        _inputVector = vector;
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


    private void Harking(Entity newEntity)
    {
        _currentGauge -= _usedGauge;
        Bar.Instance.BarValueChange(BarSliderType.Energy, _currentGauge, _maxGauge);

        newEntity.tag = "Player";
        _currentEntity.tag = "Untagged";
        newEntity.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.8f, 0.17f);
        _currentEntity.TakeDamage(int.MaxValue);

        //_currentEntity.AnimCompo.Animator.speed = 1f;
        _cinemachineCamera.Follow = newEntity.transform;

        newEntity.GetComponent<EnemyControl>().enabled = false;
        newEntity.SetMoveDire(Vector2.zero);
        newEntity.SetMoveDire(_inputVector);
        newEntity.TakeDamage(-10);
        //newEntity.AnimCompo.Animator.speed = 3f;

        _currentEntity = newEntity;
    }

    IEnumerator ReproductionGauge()
    {
        yield return new WaitForSeconds(0.5f);
        _currentGauge = Mathf.Clamp(_currentGauge+1, 0, _maxGauge);
        Bar.Instance.BarValueChange(BarSliderType.Energy, _currentGauge, _maxGauge);
        StartCoroutine(ReproductionGauge());
    }



    private void OnDisable()
    {
        Exit();
    }
}
