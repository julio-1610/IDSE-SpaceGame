using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 5f;
    //[SerializeField] float rotationalDamp = 5f;

    Transform myTransform;
    public Vector3 velocity = Vector3.zero;

    void Awake()
    {
        myTransform = transform;
    }

    void LateUpdate()
    {
        SmoothFollow();
        /*      Vector3 toPos = target.position + (target.rotation * defaultDistance);
                myTransform.position = curPos;
                Vector3 curPos = Vector3.Lerp(myTransform.position, toPos, distanceDamp * Time.deltaTime);
                Quaternion toRot = Quaternion.LookRotation(target.position - myTransform.position, target.up);
                Quaternion curRot = Quaternion.Slerp(myTransform.rotation, toRot, rotationalDamp * Time.deltaTime);
                myTransform.rotation = curRot; */
    }

    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myTransform.position, toPos, ref velocity, distanceDamp);
        myTransform.position = curPos;

        myTransform.LookAt(target, target.up);
    }
}
