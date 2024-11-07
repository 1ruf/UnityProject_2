using UnityEngine;

public class EnemyData : MonoBehaviour
{

    [SerializeField] private EnemySO Data;
   
    [Header("Stat")]
    public Sprite Visual;
    public float damage;
    public int hp;
    public float speed;
    public float detecting_Range;
    public float attackDelay;
    public GameObject Bullet;
    public SpriteRenderer gun;
    public Transform gunPos;
    

       
    [Header("else")]
    public GameObject target;
    public Vector3 direction;
    public GameObject GunCase;
  
    private void Awake()
    {
        Visual = Data.Visual;
        damage = Data.damage;
        speed = Data.speed;
        detecting_Range = Data.detecting_Range;
       
    }


}


