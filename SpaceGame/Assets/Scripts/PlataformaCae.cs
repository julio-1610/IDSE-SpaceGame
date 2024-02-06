using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    private float esperaCaida = 1f;
    private float esperaDestruir = 2f;
    private float esperaVolver = 2f;
    private Vector3 posInicial;
    private Rigidbody rb;
    private Animator animacion;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        posInicial = this.gameObject.transform.position;
        animacion = this.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida());
        }
    }

    private IEnumerator Caida()
    {
        yield return new WaitForSeconds(esperaCaida);
        rb.isKinematic = false;
        rb.useGravity = true;
        yield return new WaitForSeconds(esperaDestruir);
        this.gameObject.SetActive(false);
        Invoke("Reaparecer", esperaVolver);
    }

    private void Reaparecer()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = posInicial;
        rb.isKinematic = true;
        rb.useGravity = false;
        //rb.velocity = new Vector3(0f, 0f, 0f);
        animacion.SetBool("Reaparece", true);
    }
}
