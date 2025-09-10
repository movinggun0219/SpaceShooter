using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    const int HIT_COUNT = 3; // 몇대맞으면 터지는지
    const float DESTROY_EXP = 5.0f; //5초후에 제거
    const float DESTROY_BARREL = 3.0f; // 3초후에 드럼통 제거
    const float BARREL_MASS = 1.0f; //드럼통 무게 낮춤
    const float UP_FORCE = 1500.00f; // 위로 솟구치게하는 힘을 가함
    
    // 폭발 효과 파티클을 연결할 변수
    [SerializeField] GameObject expEffect; // 터지는거 파티클
    
    Transform tr;
    Rigidbody rb;

    // 총알을 맞은 횟수
    int hitCount = 0;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullet"))
        {
            if (++hitCount == HIT_COUNT) // 몇대맞으면 터지는지
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        GameObject exp = Instantiate(expEffect, tr.position, Quaternion.identity);
        Destroy(exp, DESTROY_EXP); //5초후에 제거

        rb.mass = BARREL_MASS; // 펑터지면서 날라가기위해서 무게 낮춤
        rb.AddForce(Vector3.up * UP_FORCE); // 위로 솟구치게하는 힘을 가함

        Destroy(gameObject, DESTROY_BARREL); // 3초후에 드럼통 제거
    }
}
