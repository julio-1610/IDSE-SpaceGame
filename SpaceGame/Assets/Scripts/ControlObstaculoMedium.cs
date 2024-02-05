using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObstaculoMedium : MonoBehaviour
{
    public GameObject prefabObstaculoMedium;
    private Vector3 posicionGenerador = new Vector3();
    private float tiempoRetraso = 5;
    private float intervaloRepeticion = 10;

    void Start()
    {
        InvokeRepeating("GeneraObstaculoMedium", tiempoRetraso, intervaloRepeticion);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneraObstaculoMediuml(){
        Instantiate(prefabObstaculoMedium, posicionGenerador, prefabObstaculoMedium.transform.rotation);
    }

}
