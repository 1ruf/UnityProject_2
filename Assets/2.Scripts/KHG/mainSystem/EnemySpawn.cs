using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Vector2 _maxSpawnPoint;
    [SerializeField] private List<GameObject> _enemy;

    [SerializeField] private Transform _enemyParent;

    public void SpawnEnemy()
    {
        foreach (GameObject enemy in _enemy)
        {
            float SP_X = Random.Range(transform.position.x-_maxSpawnPoint.x, transform.position.x+_maxSpawnPoint.x);
            float SP_Y = Random.Range(transform.position.y- _maxSpawnPoint.y/2, transform.position.y+_maxSpawnPoint.y/2);
            Vector2 SP = new Vector3(SP_X, SP_Y);
            Spawn(SP, enemy);
        }
    }   
    private void Spawn(Vector2 spawnpoint, GameObject target)
    {
        GameObject clone = Instantiate(target, _enemyParent);
        clone.transform.position = spawnpoint;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, _maxSpawnPoint);
    }
}
