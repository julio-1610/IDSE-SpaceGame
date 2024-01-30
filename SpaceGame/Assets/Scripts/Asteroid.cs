using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = .8f;
    [SerializeField] float maxScale = 1.2f;
    [SerializeField] float rotationOffset = 100f;

    Transform myTransform;
    Vector3 randomRotation;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {

        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        myTransform.localScale = scale;


        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);

        //Debug.Log(randomRotation);
    }

    void Update()
    {
        myTransform.Rotate(randomRotation * Time.deltaTime);
    }
}
