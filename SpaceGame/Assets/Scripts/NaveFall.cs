using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveFall : MonoBehaviour
{
    
    private float waitFall = 1f;
    private float waitDestroy = 2f;
    private float waitReapear = 3f;
    private Rigidbody rb;
    private Vector3 beforePosition;

// Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        beforePosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
         if (other.gameObject.CompareTag("Player")){
            StartCoroutine(Caida());
         }

    }
   
    private IEnumerator Caida(){
        yield return new WaitForSeconds(waitFall);
        rb.useGravity = enabled;
        yield return new WaitForSeconds(waitDestroy);
        this.gameObject.SetActive(false);
        Invoke("Reaparecer", waitReapear);           
    }
    private void Reaparecer(){
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = beforePosition;
        rb.useGravity = false;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
