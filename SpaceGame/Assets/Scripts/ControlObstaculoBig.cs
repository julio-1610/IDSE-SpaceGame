using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObstaculoBig : MonoBehaviour
{
    public GameObject prefabObstaculoBig;
    private Vector3 posicionGenerador = new Vector3();
    private float tiempoRetraso = 5;
    private float intervaloRepeticion = 10;

    void Start()
    {
        InvokeRepeating("GeneraObstaculoBig", tiempoRetraso, intervaloRepeticion);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneraObstaculoBig(){
        Instantiate(prefabObstaculoBig, posicionGenerador, prefabObstaculoBig.transform.rotation);
    }

}
