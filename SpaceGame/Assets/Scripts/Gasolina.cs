using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gasolina : MonoBehaviour
{
    private float velocidadRotacion = 80;
    void Update()
    {
        transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DatosJugador.datosJugadorInstance.IncrementarGasolina(1);
            Destroy(this.gameObject);
        }
    }
}
