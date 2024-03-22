using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float minSpawnTime, maxSpawnTime, timeEqualizer, timeEqualizerChangeMultiplier;
    public int carWaveSpawnSize;
    public GameObject carPaths;
    public GameObject[] enemies;

    void Start()
    {
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
        while(true)
        {
            while (carWaveSpawnSize != 0)
            {
                carWaveSpawnSize--;
                GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
                enemy.transform.position = new Vector3(-12.5f, 0, 0);
            }

            if (timeEqualizer > 0)
            {
                minSpawnTime += timeEqualizer;
            }
            else
            {

            }
            float randomizedTime = Random.Range(minSpawnTime, maxSpawnTime);
            timeEqualizer += (randomizedTime - maxSpawnTime / 2) / timeEqualizerChangeMultiplier; //tECM = kuinka monennen osan keskiarvon ylimenevästä ajasta vaikutetaan mahdollisuuteen
            yield return new WaitForSeconds(randomizedTime);
        }
    }
}
