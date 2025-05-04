using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerPool : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacle;
    [SerializeField] private int poolSize = 9;
    public int spawnIndex;

    public Vector3 spawnPos = new(25, 0, 0);

    private List<GameObject> obstaclePool = new List<GameObject>();

    private static SpawnManagerPool instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }

    public static SpawnManagerPool GetInstance()
    {
        return instance;
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObstacle();
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Acquire();
            yield return new WaitForSeconds(2f); 
        }
    }

    private void CreateNewObstacle()
    {
        spawnIndex = Random.Range(0, obstacle.Length);
        GameObject obs = Instantiate(obstacle[spawnIndex], spawnPos,obstacle[spawnIndex].transform.rotation);
        obs.SetActive(false);
        obstaclePool.Add(obs);
    }
    public GameObject Acquire()
    {
        if (obstaclePool.Count == 0)
        {
            CreateNewObstacle();
        }

        GameObject obs = obstaclePool[0];
        obstaclePool.RemoveAt(0);
        obs.SetActive(true);
        return obs;
    }

    public void Return(GameObject obstacle1)
    {
        obstacle1.transform.position = spawnPos;
        obstacle1.SetActive(false);    
        obstaclePool.Add(obstacle1);
    }
}
