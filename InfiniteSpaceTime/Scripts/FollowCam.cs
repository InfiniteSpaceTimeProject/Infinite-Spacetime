using System;
using System.Collections;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Boolean InAtmosphere = false;
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 10f;
   // [SerializeField] float rotationDamp = 10f;

    Transform myt;
    
    
    public Vector3 velocity = Vector3.one;
    
    
    void Awake()
    {
        myt = transform;
    }

    void LateUpdate()
    {
        SmoothFollow();
       /* Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.Lerp(myt.position, toPos, distanceDamp * Time.deltaTime);
        myt.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - myt.position, target.up);
        Quaternion curRot = Quaternion.Slerp(myt.rotation, toRot, rotationDamp * Time.deltaTime);
        myt.rotation = curRot;
    */}


    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myt.position, toPos, ref velocity, distanceDamp);
        myt.position = curPos;
        if (InAtmosphere)
        {
            myt.LookAt(target, target.up);
        }
        else
        {
            myt.LookAt(target, target.up);
        }
    }

}
    