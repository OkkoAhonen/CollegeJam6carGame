using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float startingScore = 0f; // Alkupisteet
    public float scoreIncreaseRate = 5f; // Pisteiden kasvunopeus per sekunti
    private float currentScore; // Pelaajan nykyinen pistemäärä

    public PlayerScript playerScript;
    /*
    bool laskuri2 = playerScript.laskuri;
   
    

    void Start()
    {
        currentScore = startingScore; // Aseta alkupisteet
    }

    void Update()
    {
        IncreaseScoreOverTime(); // Kasvata pistemäärää ajan kuluessa
         // Tulosta pistemäärä konsoliin
    }
    private void FixedUpdate()
    {
        PrintScoreToConsole();
    }

    void IncreaseScoreOverTime()
    {
        if (playerscript.laskuri = true) { 
        currentScore += scoreIncreaseRate * Time.deltaTime; // Kasvata pistemäärää
    }
}

void PrintScoreToConsole()
    {
        int roundedScore = Mathf.RoundToInt(currentScore);
        Debug.Log("Score: " + roundedScore); // Tulosta pistemäärä konsoliin
    }

    // Metodi, jolla voi hakea nykyisen pistemäärän
    public float GetCurrentScore()
    {
        return currentScore;
    }
}
*/
}