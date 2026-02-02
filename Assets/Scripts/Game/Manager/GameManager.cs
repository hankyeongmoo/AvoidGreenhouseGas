using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GHG Settings")]
    public List<GameObject> ghgPrefabs;
    public List<float> ghgSpawnIntervals;
    public List<float> ghgTimers;

    [Header("Game Settings")]
    public float gameDuration = 60f; // 1 minute

    void FixedUpdate()
    {
        if (MySceneManager.currentScene == "Game")
        {
            Game();
        }
    }

    void Game()
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

        // Interval 변환
        ghgSpawnIntervals[0] = 10 / Mathf.Lerp(460, 700, ghgTimers[0] / 60f);
        ghgSpawnIntervals[1] = 10 / Mathf.Lerp(44, 35, ghgTimers[1] / 60f);
        ghgSpawnIntervals[2] = 10 / Mathf.Lerp(15, 10, ghgTimers[2] / 60f);
        ghgSpawnIntervals[3] = 10 / Mathf.Lerp(3, 30, ghgTimers[3] / 60f);
        ghgSpawnIntervals[4] = 10 / Mathf.Lerp(2, 4, ghgTimers[4] / 60f);
        ghgSpawnIntervals[5] = 10 / Mathf.Lerp(2, 10, ghgTimers[5] / 60f);

        // 플레이 시간 제한
        gameDuration -= Time.deltaTime;
        if (gameDuration <= 0f)
        {
            MySceneManager.currentScene = "GoodEnd";
            Debug.Log("굳 엔딩");
        }
    }

    void SpawnGHG(int index)
    {
        float xPosition = Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(xPosition, 10f, 0f);
        Instantiate(ghgPrefabs[index], spawnPosition, Quaternion.identity);
    }
}
