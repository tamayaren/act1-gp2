using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private RotationBehavior rotationBehavior;
    private Transform playerTransform;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeElapsed = 0f;
    [SerializeField] private float nextEnemy = 1f;

    private GameObject player;

    private void Start()
    {
        playerTransform = rotationBehavior.gameObject.transform;
    }

    private Vector3 GetRandom()
    {
        float radius = rotationBehavior.maxDistance + 16f;

        Vector3 randomPosition = Random.insideUnitSphere * radius;
        randomPosition += playerTransform.position;
        randomPosition.y = 0f;

        Vector3 directional = randomPosition - playerTransform.position;
        directional.Normalize();

        float product = Vector3.Dot(playerTransform.forward, directional);
        float productAngle = Mathf.Acos(product / playerTransform.forward.magnitude * directional.magnitude);

        randomPosition.x = Mathf.Cos(productAngle) * radius + playerTransform.position.x;
        randomPosition.z = Mathf.Sin(productAngle * (Random.value > .5f ? 1f : -1f)) * radius + playerTransform.position.z;

        return randomPosition;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0) return;
        this.timeElapsed += Time.deltaTime;

        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = GetRandom();
    }
}
