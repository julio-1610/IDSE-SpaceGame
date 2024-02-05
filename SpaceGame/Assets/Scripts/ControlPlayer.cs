using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    float movementSpeed = 20;
    Transform myT;
    Rigidbody rb;

    void Awake()
    {
        myT = transform;
        rb = GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        Movement();
        rb.useGravity = Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0;
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
        {
            myT.position += myT.forward * movementSpeed * Time.deltaTime * horizontal;
        }
        else if (horizontal < 0)
        {
            myT.position -= myT.forward * movementSpeed * Time.deltaTime * -horizontal;
        }

        if (vertical != 0)
        {
            myT.position += myT.up * movementSpeed * Time.deltaTime * vertical;
        }
    }

    private void onCollisionEnter(Collision c)
    {
        Vector3 position = transform.position;
        position.z = Mathf.Clamp(position.z, 10f, 10f);
        transform.position = position;
    }
}
