using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionMercurio : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mercurio"))
        {
            // Desactivar la nave
            gameObject.SetActive(false);

            // Mostrar mensaje
            Debug.Log("Nivel 2 COMPLETADO");
        }
    }
}