using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    // [SerializeField] Rigidbody rigidbody;
    public void IvBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 6f);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if(collision.gameObject.tag != "Plataforma")
                IvBeenHit(contact.point);
        }   
    }

    /*  public void AddForce(Vector3 hitPosition, Transform hitSource)
     {
         if (rigidbody == null)
         {
             return;
         }
         Vector3 direction = hitSource.position - hitPosition;
         rigidbody.AddForceAtPosition(direction.normalized, hitPosition);

     } */
}
