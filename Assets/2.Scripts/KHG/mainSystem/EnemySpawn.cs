using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private List<GameObject> _enemy;

    [SerializeField] private Transform _enemyParent;

    private void OnEnable()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        foreach (Transform ts in _spawnPoint)
        {
            int enemyType = Random.Range(0,_enemy.Count);
            Spawn(ts, _enemy[enemyType]);
        }
    }
    private void Spawn(Transform spawnpoin, GameObject target)
    {
        GameObject clone = Instantiate(target, _enemyParent);
        clone.transform.position = spawnpoin.position;
    }
}
