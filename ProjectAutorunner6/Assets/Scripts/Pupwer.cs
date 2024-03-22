using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupwer : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {

}
    private void Update()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        if (Input.GetKeyDown(KeyCode.K))
        {

            Instantiate(myPrefab, new Vector3(-5, 0, 0), Quaternion.identity);
        }
    }
}
