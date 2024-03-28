using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;

public class EnemyCarScript : MonoBehaviour
{
    public float enemySpeed, stopSpeed;
    private bool hadInside;

    public LayerMask checkedLayers; // Mitkä objektit tarkistaa
    
    Rigidbody2D rb;

    private AudioManager audioManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;

        audioManager = FindObjectOfType<AudioManager>();
    }

    public void SetDestination(GameObject path)
    {
        transform.position = path.transform.GetChild(1).transform.position;

        Vector3 direction = path.transform.GetChild(2).transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        rb.velocity = direction * enemySpeed;
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + transform.up * 2.3f, new Vector2(1, 2), transform.rotation.z, checkedLayers);

        if (colliders.Length > 0 )
        {
            if (!hadInside)
            {
                hadInside = true;
                rb.drag = stopSpeed;
                audioManager.Play("Honk");
            }
            foreach (Collider2D collider in colliders)
            {
                //Debug.Log("Object inside trigger: " + collider.name);
            }
        }
        else
        {
            if (hadInside)
            {
                hadInside = false;
                rb.drag = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.magenta;
        Gizmos.DrawWireCube(transform.position + transform.up * 2.3f, new Vector2(1, 2));
    }
}
