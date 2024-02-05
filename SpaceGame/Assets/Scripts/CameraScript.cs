using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;


    void Update()
    {
        Vector3 newCameraPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = newCameraPosition;
    }
}
