using System.Collections;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] float fallSpeed = 0.1f;
    [SerializeField] float spawnInterval = 0.1f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        InvokeRepeating("Fall", 0, spawnInterval);
    }

    void Fall()
    {
        if (transform.position.y <= 0) // Asume que el suelo está en y = 0
        {
            // Si el meteorito ha llegado al suelo, restablece su posición a la inicial
            transform.position = initialPosition;
        }
        else
        {
            // Si el meteorito aún no ha llegado al suelo, sigue cayendo
            transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Asumiendo que tienes una referencia a tu script CheckPoint en tu player
            CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();
            checkPoint.ResetToLastCheckpoint();
        }
    }
}
