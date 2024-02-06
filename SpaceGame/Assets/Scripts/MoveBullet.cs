using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float velocity;
    public bool movement;
    public GameObject copy;
    public float time;
    private Vector3 positionInit;
    private Quaternion rotationInit;
    
    void Start()
    {
        positionInit = this.gameObject.transform.position;
	rotationInit = this.gameObject.transform.rotation;
        InvokeRepeating("Create", time, 0);
    }

    // Update is called once per frame
    void Update()
    {	
	if(movement == true)
            transform.Translate(Vector3.down*velocity*Time.deltaTime);
	else 
	    transform.Translate(Vector3.up*velocity*Time.deltaTime);
    }
    void Create(){
        Instantiate(copy, positionInit, rotationInit);
        Destroy(this.gameObject);
    }
}
