using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_S))]
public class EnemyMovement_S : MonoBehaviour
{
    private Transform target;
    private Enemy_S targetEnemy;
    private int wavepointIndex = 0;

    private Enemy_S enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy_S>();
        target = Waypoints_S.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints_S.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints_S.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats_S.lives--;
        WaveSpawner_S.enemiesAlive--;
        Destroy(gameObject);
    }
}
