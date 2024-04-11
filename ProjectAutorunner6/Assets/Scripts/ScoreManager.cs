using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float startingScore = 0f; // Alkupisteet
    public float scoreIncreaseRate = 5f; // Pisteiden kasvunopeus per sekunti
    private float currentScore; // Pelaajan nykyinen pistem‰‰r‰

    public PlayerScript playerScript;

    bool laskuri2 = playerScript.laskuri;
   
    

    void Start()
    {
        currentScore = startingScore; // Aseta alkupisteet
    }

    void Update()
    {
        IncreaseScoreOverTime(); // Kasvata pistem‰‰r‰‰ ajan kuluessa
         // Tulosta pistem‰‰r‰ konsoliin
    }
    private void FixedUpdate()
    {
        PrintScoreToConsole();
    }

    void IncreaseScoreOverTime()
    {
        if (playerscript.laskuri = true) { 
        currentScore += scoreIncreaseRate * Time.deltaTime; // Kasvata pistem‰‰r‰‰
    }
}

void PrintScoreToConsole()
    {
        int roundedScore = Mathf.RoundToInt(currentScore);
        Debug.Log("Score: " + roundedScore); // Tulosta pistem‰‰r‰ konsoliin
    }

    // Metodi, jolla voi hakea nykyisen pistem‰‰r‰n
    public float GetCurrentScore()
    {
        return currentScore;
    }
}
