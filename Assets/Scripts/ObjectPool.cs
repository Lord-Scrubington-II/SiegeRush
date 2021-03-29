using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolCapacity = 5;
    [SerializeField] float spawnDelay = 1.0f;
    [SerializeField] bool spawnClockActive = true;

    GameObject[] pool;

    private void Awake()
    {
        PreprocessObjectPool();
    }

    private void PreprocessObjectPool()
    {
        pool = new GameObject[poolCapacity];

        for(int i = 0; i < poolCapacity; i++)
        {
            pool[i] = GameObject.Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawnClock();
    }

    private IEnumerator EnemySpawnClock()
    {
        while (spawnClockActive)
        {
            ExtractPoolMember();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void ExtractPoolMember()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    private void StartSpawnClock()
    {
        StartCoroutine(nameof(EnemySpawnClock));
    }

    private void StopSpawnClock()
    {
        StopCoroutine(nameof(EnemySpawnClock));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
