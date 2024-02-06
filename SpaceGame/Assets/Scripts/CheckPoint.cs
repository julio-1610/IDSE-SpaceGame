using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkpoints;
    private Vector3 lastCheckpointPosition;
    private Quaternion lastCheckpointRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillZone") && lastCheckpointPosition != null)
        {
            player.transform.position = lastCheckpointPosition;
            player.transform.rotation = lastCheckpointRotation;
        }
        else if (checkpoints.Contains(other.gameObject))
        {
            lastCheckpointPosition = other.transform.position;
            lastCheckpointRotation = other.transform.rotation;
            Destroy(other.gameObject);
        }
    }

    public void ResetToLastCheckpoint()
    {
        if (lastCheckpointPosition != null)
        {
            player.transform.position = lastCheckpointPosition;
            player.transform.rotation = lastCheckpointRotation;
        }
    }

}
