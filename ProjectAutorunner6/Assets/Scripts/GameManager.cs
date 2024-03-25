using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public float minSpawnTime, maxSpawnTime, timeEqualizer, timeEqualizerChangeMultiplier;
    public GameObject carPaths;
    public GameObject[] enemies;
    private List<GameObject> paths = new();

    private GameObject gameHolder;

    void Start()
    {
        gameHolder = GameObject.Find("GameHolder");
        foreach (Transform transPath in carPaths.transform)
        {
            GameObject path = transPath.gameObject;
            paths.Add(path);
        }
        StartGame();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        float randomizedTime;
        int waveSize;
        List<GameObject> pathsInThisWave;
        while (true)
        {
            waveSize = Random.Range(2, 4);
            pathsInThisWave = new List<GameObject>(paths);

            while (waveSize != 0)
            {
                waveSize--;
                GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length - 1)], gameHolder.transform); //Spawns random enemy from enemies

                int childIndex = pathsInThisWave.Count;
                GameObject path = pathsInThisWave[Random.Range(0, childIndex)]; //Chooses which path cars take
                pathsInThisWave.Remove(path);
                EnemyCarScript enemyScript = enemy.GetComponent<EnemyCarScript>();
                enemyScript.SetDestination(path);
            }

            randomizedTime = timeEqualizer > 0
                ? Random.Range(minSpawnTime, maxSpawnTime - timeEqualizer)
                : Random.Range(minSpawnTime + timeEqualizer, maxSpawnTime);
            timeEqualizer += (randomizedTime - maxSpawnTime / 2) / timeEqualizerChangeMultiplier; //tECM = kuinka monennen osan keskiarvon ylimenevästä ajasta vaikutetaan ajastimeen
            yield return new WaitForSeconds(randomizedTime);
        }
    }
}
