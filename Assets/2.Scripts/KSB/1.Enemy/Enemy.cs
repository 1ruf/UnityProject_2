using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    public  static Enemy instance;
    // �׽�Ʈ
    public Action around;
    public Enemy Instance
    {
        get
        {
            if (instance == null)
            {

                instance = FindObjectOfType<Enemy>();


                if (instance == null)                                                
            {
                    GameObject singletonObject = new GameObject(); // singletonobject��� ���� ������Ʈ ����
                    instance = singletonObject.AddComponent<Enemy>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
    [field: SerializeField] public Rigidbody2D rigid { get; set; }
    [field: SerializeField] public SpriteRenderer spriteRenderer { get; private set; }
    [field: SerializeField] public Animator animator { get; set; }
    [field: SerializeField] public EnemyStateMachine stateMachine { get; set; }

    public float Espeed = 5;
    public bool _attack = false;
    public bool _follow= false;
    [SerializeField] private string currentStateCheck;

    public Pointer pointer;

    private KSBPlayer _target;
    [SerializeField] public int _damage = 1;
    [SerializeField] public int _attack_Speed = 1;
    public int Speed = 1;


    public KSBPlayer Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigid = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        stateMachine = new EnemyStateMachine();

        stateMachine.AddState(EnemyStateEnum.Idle, new Enemy_Idle_State(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyStateEnum.Attack, new Enemy_Attack_State(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyStateEnum.Death, new Enemy_Death_State(this, stateMachine, "Death"));
        stateMachine.AddState(EnemyStateEnum.Follow, new Enemy_Follow_State(this, stateMachine, "follow"));

        pointer = GetComponentInChildren<Pointer>();

        instance = this;
     
        

    }
    private void Start()
    {
     
        stateMachine.Initialize(EnemyStateEnum.Idle);

    }
    public void Update()
    {
        currentStateCheck = stateMachine.currentState.ToString();
        stateMachine.currentState.Update();

   
        if (_attack)
        {
            stateMachine.ChangeState(EnemyStateEnum.Attack);
        }
        else if (!_attack && _follow)
        {
            stateMachine.ChangeState(EnemyStateEnum.Follow);
        }
        else if (_follow)
        {
            stateMachine.ChangeState(EnemyStateEnum.Follow);
        }
        else if(!_follow)
        {
            stateMachine.ChangeState(EnemyStateEnum.Idle);
        }

    }

}
