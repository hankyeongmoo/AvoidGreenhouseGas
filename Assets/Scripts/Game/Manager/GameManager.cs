using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> ghgPrefabs;
    public List<float> ghgSpawnIntervals;
    public List<float> ghgTimers;

    void FixedUpdate()
    {
        // GHG 스폰
        for (int i = 0; i < ghgPrefabs.Count; i++)
        {
            ghgTimers[i] += Time.deltaTime;
            if (ghgTimers[i] >= ghgSpawnIntervals[i])
            {
                SpawnGHG(i);
                ghgTimers[i] = 0f;
            }
        }
    }

    void SpawnGHG(int index)
    {
        float xPosition = Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(xPosition, 10f, 0f);
        Instantiate(ghgPrefabs[index], spawnPosition, Quaternion.identity);
    }
}
