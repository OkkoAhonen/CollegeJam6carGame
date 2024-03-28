using UnityEngine;

public class AutoLiikkuu : MonoBehaviour
{
    public float nopeus = 5f; // Auton nopeus
    private Rigidbody2D rb;
    private Vector2 suunta;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        asetaSuunta();
    }

    void Update()
    {
        liiku();
    }

    void liiku()
    {
        // Liikuta autoa nykyisen suunnan mukaisesti
        rb.MovePosition(rb.position + suunta * nopeus * Time.fixedDeltaTime);

        // Jos auto menee ruudun ulkopuolelle, aseta uusi suunta
        if (rb.position.x > Screen.width || rb.position.x < 0 || rb.position.y > Screen.height || rb.position.y < 0)
        {
            asetaSuunta();
        }
    }

    void asetaSuunta()
    {
        // Aseta satunnainen suunta
        float xSuunta = Random.Range(0f, 1f);
        suunta = new Vector2(1, 0).normalized;
    }
}

