using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTracker : MonoBehaviour
{
    public GameObject Player;
    public GameObject Workplace;

    public float Distance;

    void Start()
    {
        
    }

    void Update()
    {
        // Calculate the distance between player and workplace
        Distance = Vector3.Distance(Player.transform.position, Workplace.transform.position);

        // Output the distance to the console
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log($"Distance to workplace: {Distance} meters");
        }
        
    }
}
