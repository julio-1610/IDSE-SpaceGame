using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkpoints;
    private Vector3 lastCheckpointPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone") && lastCheckpointPosition != null)
        {
            player.transform.position = lastCheckpointPosition;
        }
        else if (checkpoints.Contains(other.gameObject))
        {
            lastCheckpointPosition = other.transform.position;
            Destroy(other.gameObject);  
        }
    }
}
