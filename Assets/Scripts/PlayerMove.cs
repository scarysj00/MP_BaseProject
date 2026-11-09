using UnityEngine;
using UnityEngine.InputSystem;

// 2주차 베이스용 간단 이동 스크립트.
// 키보드 방향키/WASD로 움직인다.
// New Input System으로 리팩토링합니다.
public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    PlayerControls controls;   // 실습 2에서 생성한 클래스
    Vector2 moveInput;

    public PlayerControls Controls => controls;   // Rebinder가 밖에서 읽는 통로

    void Awake()
    {
        controls = new PlayerControls();

        // Move Action이 값을 낼 때마다 moveInput에 저장
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Interact.performed += ctx => Debug.Log("Interact!");
    }

    void OnEnable() { controls.Enable(); }
    void OnDisable() { controls.Disable(); }

    void Update()
    {
        Vector3 dir = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.position += dir * speed * Time.deltaTime;
    }
}
