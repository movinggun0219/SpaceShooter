using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0, 5, -10);
    public float cameraFollowSpeed = 5f;

    private float moveHorizontal;
    private float moveVertical;
    private bool jumpRequest;

    void Update()
    {
        // 1. 입력 처리: 방향키 입력 받기
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        // 점프 입력 감지 (스페이스바)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        // 2. 물리 이동 처리
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed;
        Vector3 newVelocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        rb.velocity = newVelocity;

        // 점프 처리 (간단히 땅에 있을 때만 점프 허용)
        if (jumpRequest && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequest = false;
        }
    }

    void LateUpdate()
    {
        // 3. 카메라 부드럽게 따라가기
        Vector3 desiredPosition = transform.position + cameraOffset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, cameraFollowSpeed * Time.deltaTime);

        // 카메라가 플레이어를 항상 보도록 회전
        cameraTransform.LookAt(transform);
    }

    bool IsGrounded()
    {
        // 간단한 바닥 체크 (플레이어 위치 아래에 레이 쏘기)
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
