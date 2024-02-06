using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeTuberias : MonoBehaviour
{
    public GameObject PipePrefab;
    private GameObject PipesHolder;
    private float PipeSpawnInterval = 2;
    private float PipesSpeed = 5;
    private float PipeSpawnCountdown;
    private int PipeCount;

    void Start()
    {
        // Inicializar tuberías
        PipeCount = 0;
        PipesHolder = new GameObject("PipesHolder");
        PipesHolder.transform.parent = this.transform;

        // Inicializar tiempo de generación de tuberías
        PipeSpawnCountdown = 0;
    }

    void Update()
    {
        // Generar tuberías
        PipeSpawnCountdown -= Time.deltaTime;
        if (PipeSpawnCountdown <= 0)
        {
            PipeSpawnCountdown = PipeSpawnInterval;

            // Crear tubería
            GameObject pipe = Instantiate(PipePrefab);
            pipe.transform.parent = PipesHolder.transform;
            pipe.transform.name = (++PipeCount).ToString();

            pipe.transform.position += Vector3.right * 30;
            pipe.transform.position += Vector3.up * Mathf.Lerp(4, 9, Random.value);
        }

        // Mover tuberías hacia la izquierda
        PipesHolder.transform.position += Vector3.left * PipesSpeed * Time.deltaTime;
    }
}
