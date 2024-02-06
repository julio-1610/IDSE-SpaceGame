using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovil : MonoBehaviour
{
    public float movementSpeed;
    private float positionInicial;
    // Start is called before the first frame update
    void Start() {
        positionInicial = this.transform.position.x;
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        if(this.transform.position.x > positionInicial + 10f)
            movementSpeed *= -1;
        else if(this.transform.position.x < positionInicial)
            movementSpeed *= -1; 
    }
}
