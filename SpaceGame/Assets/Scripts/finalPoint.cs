using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalPoint : MonoBehaviour
{
    public Vector3 lastPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroide"))
        {
            Death();
        }
    }

    public void Death()
    {
        transform.position = lastPoint;
    }
}
