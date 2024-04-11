using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float accelerationSpeed, maxSpeed, turnpower, carHealth, currentSpeed;
    public bool laskuri = true;

    void Start()
    {

    }


    void FixedUpdate()
    {
        Drive();
    }

    void Drive()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnpower / (1 + currentSpeed * 0.15f)); //K‰‰ntyy hitaammin, mit‰ nopeamin menee
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnpower / (1 + currentSpeed * 0.15f));
        }

        transform.position -= new Vector3(0, transform.rotation.z + 0.00001f * -currentSpeed * transform.rotation.z, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "pahis")
        {
            laskuri = false;
            Debug.Log("Pahis kuollu ja sina kuollu");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
