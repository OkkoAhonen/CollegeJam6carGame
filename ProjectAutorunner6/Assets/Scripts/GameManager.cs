using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float enemySpeed, minSpawnTime, maxSpawnTime, timeEqualizer, timeEqualizerChangeMultiplier;
    public GameObject carPaths;
    public GameObject[] enemies;
    public List<GameObject> paths = new();

    void Start()
    {
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
            waveSize = Random.Range(1, 3);
            pathsInThisWave = paths;
            waveSize--;

            while (waveSize != 0)
            {
                GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length - 1)]); //Spawns random enemy from enemies

                int childIndex = pathsInThisWave.Count;
                GameObject path = pathsInThisWave[Random.Range(0, childIndex)]; //Chooses which path cars take
                pathsInThisWave.Remove(path); //Jostain syystä poistaa paths listasta myös!!
                foreach (GameObject p in pathsInThisWave)
                {
                    Debug.Log(p);
                }

                enemy.transform.position = path.transform.GetChild(1).transform.position;
                Debug.Log(path.transform.GetChild(1).name + " " + path.transform.GetChild(1).transform.position);
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
                Vector3 direction = (path.transform.GetChild(2).transform.position - transform.position);
                rb.velocity = direction * enemySpeed;
            }

            randomizedTime = timeEqualizer > 0
                ? Random.Range(minSpawnTime, maxSpawnTime - timeEqualizer)
                : Random.Range(minSpawnTime + timeEqualizer, maxSpawnTime);
            timeEqualizer += (randomizedTime - maxSpawnTime / 2) / timeEqualizerChangeMultiplier; //tECM = kuinka monennen osan keskiarvon ylimenevästä ajasta vaikutetaan ajastimeen
            yield return new WaitForSeconds(randomizedTime);
        }
    }
}
