using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform tragetTr;
    Transform camTr;

    [Range(2.0f, 20.0f)] public float distance = 10.0f;
    [Range(0.0f, 10.0f)] public float height = 2.0f;

    public float damping = 10.0f; // 반응속도
    public float targetOffset = 2.0f;

    private Vector3 velocity = Vector3.zero;

        void Start()
    {
        camTr = GetComponent<Transform>();
    }

    void Update()
    {
        
    }
    void LateUpdate()
    {
       

        Vector3 pos = tragetTr.position
                        + (-tragetTr.forward * distance)
                        + (Vector3.up * height);
        //camTr.position = Vector3.Slerp(camTr.position, pos, Time.deltaTime * damping);

        camTr.position = Vector3.SmoothDamp(camTr.position, pos, ref velocity, damping);
        camTr.LookAt(tragetTr.position + (tragetTr.up * targetOffset));
    }

}
