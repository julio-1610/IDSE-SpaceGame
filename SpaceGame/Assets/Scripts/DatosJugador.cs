using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DatosJugador : MonoBehaviour
{
    public static DatosJugador datosJugadorInstance;
    public TextMeshProUGUI gasolina;
    private int numGasolina = 0;

    void Awake()
    {
        if (datosJugadorInstance == null)
        {
            datosJugadorInstance = this;
        }
    }

    public void IncrementarGasolina(int g)
    {
        numGasolina++;
        gasolina.text = "Gasolina: " + numGasolina;
    }
}
