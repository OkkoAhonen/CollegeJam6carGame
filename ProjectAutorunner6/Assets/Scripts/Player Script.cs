using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float accelerationSpeed, maxSpeed, turnpower, carHealth, currentSpeed;

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
            transform.Rotate(Vector3.forward * turnpower / (1 + currentSpeed * 0.15f)); //K��ntyy hitaammin, mit� nopeamin menee
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnpower / (1 + currentSpeed * 0.15f));
        }

        transform.position -= new Vector3(0, transform.rotation.z + 0.00001f * -currentSpeed * transform.rotation.z, 0);

    }
}