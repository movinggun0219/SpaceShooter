using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    void Start()
    {

    }

    void Update()
    {
        // 마우스 왼쪽 클릭했을때 Fire함수 호출
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }


    }
    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
