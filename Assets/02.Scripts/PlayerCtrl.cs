using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Transform tr;

    [SerializeField]  float moveSpeed = 10.0f;
    
    [SerializeField]  float turnSpeed = 80.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");
        Debug.Log($"h = {h} ");
        Debug.Log($"v = {v} ");


        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

    }
}
