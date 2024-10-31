using UnityEngine;

public class Sensing : MonoBehaviour
{
    private float _circle_Size;
    [SerializeField] private LayerMask Targetlayer;
    public bool Detected = false;
    public bool Attack = false;

    [SerializeField]private KSB_Enemy _agent;
    Vector3 _enemyPos;
    public  float decetingLength = 2f;

    private void Update()
    {
        _circle_Size = _agent.enemyData.detecting_Range;
        _enemyPos = _agent.transform.position;
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
        _agent.enemyData.target = Physics2D.OverlapCircle(_enemyPos, _circle_Size, Targetlayer).gameObject;
        if (_agent.enemyData.target != null)
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
        float distance = Vector2.Distance(_agent.transform.position, _agent.enemyData.target.transform.position);
        if (distance <= decetingLength)
        {
            Attack = true;
        }
        else
        {
            Attack = false;
        }

    }


}
