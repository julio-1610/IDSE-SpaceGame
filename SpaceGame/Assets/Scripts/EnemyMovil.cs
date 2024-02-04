using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovil : MonoBehaviour
{
    private float movementSpeed = 5f;
    // Start is called before the first frame update

    void FixedUpdate()
    {
        this.transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        if(transform.position.x > 16)
            movementSpeed *= -1;
        else if(transform.position.x < 8f)
            movementSpeed *= -1; 
    }
}
