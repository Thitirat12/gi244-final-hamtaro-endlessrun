using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public Vector3 spawnPos = new(25, 0, 0);
    public int spawnIndex;

    public float startDelay = 2;
    public float repeatRate = 2;

    private PlayerController playerController;

    

    void Start()
    {
        // Instantiate(obstaclePrefab, new Vector3(25, 0, 0), obstaclePrefab.transform.rotation);

        InvokeRepeating(nameof(SpawnObstacle), 2, 2);

        GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        spawnIndex = Random.Range(0, obstaclePrefab.Length);
        Instantiate(
            obstaclePrefab[spawnIndex],
            spawnPos,
            obstaclePrefab[spawnIndex].transform.rotation
        );
        //Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
