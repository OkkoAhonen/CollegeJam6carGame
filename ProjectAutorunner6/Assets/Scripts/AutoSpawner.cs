using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    public GameObject autoPrefab;
    public Transform[] spawnPisteet;
    public float spawnAikaV�li = 5f; // Aika sekunneissa joka v�lein auto spawnataan
    private float viimeSpawnAika;

    void Update()
    {
        // Tarkista, onko aika spawnaus
        if (Time.time > viimeSpawnAika + spawnAikaV�li)
        {
            SpawnAuto();
            viimeSpawnAika = Time.time;
        }
    }

    void SpawnAuto()
    {
        // Valitse satunnainen spawn-piste
        Transform spawnPiste = spawnPisteet[Random.Range(0, spawnPisteet.Length)];

        // Spawnaa auto valittuun pisteeseen
        GameObject spawnedAuto = Instantiate(autoPrefab, spawnPiste.position, Quaternion.identity);

        // Liit� AutoLiikkuu-skripti spawnaattuun autoon
        AutoLiikkuu autoLiikkuu = spawnedAuto.GetComponent<AutoLiikkuu>();
        if (autoLiikkuu != null)
        {
            autoLiikkuu.enabled = true; // Ota AutoLiikkuu-skripti k�ytt��n
        }
        else
        {
            Debug.LogError("AutoLiikkuu-skripti� ei l�ydetty spawnaatusta autosta!");
        }
    }
}
