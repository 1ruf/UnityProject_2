using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRoom_HG : MonoBehaviour
{
    [SerializeField] private GameObject _blocker, _parent;
    [SerializeField] private EnemySpawn _spawnScr;

    private bool locked;
    private void OnEnable()
    {
        locked = false;
        _blocker.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (locked == true)
            if (CheckChild())
                RoomClear();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && locked == false)
        {
            locked = true;
            _blocker.SetActive(true);
            _spawnScr.SpawnEnemy();
        }
    }
    public void RoomClear()
    {
        _blocker.SetActive(false);
        Destroy(transform.parent);
    }

    private bool CheckChild()
    {
        return (_parent.transform.childCount <= 0);
    }
}
