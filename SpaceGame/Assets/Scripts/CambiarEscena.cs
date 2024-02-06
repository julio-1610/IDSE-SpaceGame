using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && !player.activeSelf)
        {
            SceneManager.LoadScene(3);
        }
    }
}