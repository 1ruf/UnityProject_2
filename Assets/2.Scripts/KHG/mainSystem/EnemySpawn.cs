using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Vector2 _maxSpawnPoint;
    [SerializeField] private List<GameObject> _enemy;

    [SerializeField] private Transform _enemyParent;

    public List<GameObject> cloneEnemys;
    public void SpawnEnemy()
    {
        foreach (GameObject enemy in _enemy)
        {
            float SP_X = Random.Range(-_maxSpawnPoint.x/2,_maxSpawnPoint.x/2);
            float SP_Y = Random.Range(-_maxSpawnPoint.y/2,_maxSpawnPoint.y/2);
            Vector3 SP = new Vector3(SP_X, SP_Y);
            Spawn(transform.position + SP, enemy);
        }
    }   
    private void Spawn(Vector2 spawnpoint, GameObject target)
    {
        GameObject clone = Instantiate(target, null);
        clone.transform.position = spawnpoint;
        cloneEnemys.Add(clone);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, _maxSpawnPoint);
    }
}
