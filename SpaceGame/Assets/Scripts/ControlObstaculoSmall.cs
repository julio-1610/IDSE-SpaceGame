using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObstaculoSmall : MonoBehaviour
{
    public GameObject prefabObstaculoSmall;
    private Vector3 posicionGenerador = new Vector3();
    private float tiempoRetraso = 5;
    private float intervaloRepeticion = 10;

    void Start()
    {
        InvokeRepeating("GeneraObstaculoSmall", tiempoRetraso, intervaloRepeticion);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneraObstaculoSmall(){
        Instantiate(prefabObstaculoSmall, posicionGenerador, prefabObstaculoSmall.transform.rotation);
    }

}
