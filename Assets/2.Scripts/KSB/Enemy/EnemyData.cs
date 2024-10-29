using UnityEngine;

public class EnemyData : MonoBehaviour
{

    [SerializeField] private EnemySO Data;
   
    [Header("Stat")]
    public float damage;
    public int hp;
    public float speed;
    public float detecting_Range;

    [Header("else")]
    public Sprite Visual;
    public Collider2D target;
    private void Awake()
    {
        Visual = Data.Visual;
        damage = Data.damage;
        speed = Data.speed;
        detecting_Range = Data.detecting_Range;
    }


}


