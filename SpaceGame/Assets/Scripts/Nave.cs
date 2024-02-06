using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float Gravity = 30;
    public float Jump = 10;

    private float VerticalSpeed;

    void Update()
    {
        // Aplicar gravedad
        VerticalSpeed += -Gravity * Time.deltaTime;

        // Saltar al presionar la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VerticalSpeed = Jump;
        }

        // Mover la nave verticalmente
        transform.position += Vector3.up * VerticalSpeed * Time.deltaTime;
    }
}
