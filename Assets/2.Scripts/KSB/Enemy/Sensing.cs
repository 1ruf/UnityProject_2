using UnityEngine;

public class Sensing : MonoBehaviour
{
    [SerializeField] private float _circle_Size = 1f;
    [SerializeField] private LayerMask Targetlayer;
    public bool Detected = false;
    public bool Attack = false;

    [SerializeField] private KSB_Enemy _agent;

    float _distance;
    float _refDis = 1;
    Vector3 _enemyPos;


    private void Awake()
    {
      
        _enemyPos = _agent.transform.position;
    }

    private void Update()
    {
        _enemyPos = _agent.transform.position;
        Detecting();
    }

    private void OnDrawGizmos()
    {
        if (_agent != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_enemyPos, _circle_Size);
        }
        else
        {
            Debug.Log("¾øÀ½");
        }
    }

    private void Detecting()
    {
        _agent.target = Physics2D.OverlapCircle(_enemyPos, _circle_Size, Targetlayer);
        if (_agent.target != null)
        {
            Debug.Log("Target detected");
            Detected = true;
            AttackDecting();
        }
        else
        {
            Detected = false;
            Attack = false;

        }
    }

    private void AttackDecting()
    {
        float distance = Vector2.Distance(_agent.transform.position, _agent.target.transform.position);
        if (distance <= 1.7f)
        {
            Attack = true;
        }
        else
        {
            Attack = false;
        }

    }


}
