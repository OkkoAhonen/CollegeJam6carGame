using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    public GameObject autoPrefab;
    public Transform[] spawnPisteet;
    public float spawnAikaVäli = 5f; // Aika sekunneissa joka välein auto spawnataan
    private float viimeSpawnAika;

    void Update()
    {
        // Tarkista, onko aika spawnaus
        if (Time.time > viimeSpawnAika + spawnAikaVäli)
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

        // Liitä AutoLiikkuu-skripti spawnaattuun autoon
        AutoLiikkuu autoLiikkuu = spawnedAuto.GetComponent<AutoLiikkuu>();
        if (autoLiikkuu != null)
        {
            autoLiikkuu.enabled = true; // Ota AutoLiikkuu-skripti käyttöön
        }
        else
        {
            Debug.LogError("AutoLiikkuu-skriptiä ei löydetty spawnaatusta autosta!");
        }
    }
}
