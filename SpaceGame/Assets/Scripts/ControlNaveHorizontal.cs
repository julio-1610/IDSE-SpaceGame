using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNaveHorizontal : MonoBehaviour
{
    [SerializeField] float movementSpeed = 20f;
    [SerializeField] float turnSpeed = 100f;


    Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    void Update()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float InputX = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        myTransform.Rotate(InputX, 0, 0);
    }

    void Thrust()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }
    }
    private void onCollisionEnter(Collision c) {
        Vector3 position = transform.position;
        position.z = Mathf.Clamp(position.z, 10f, 10f);
        transform.position = position;
    }
}
