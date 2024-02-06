using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        other.transform.SetParent(this.transform);
    }
}
