using UnityEngine;
using UnityEngine.InputSystem;

public class DeviceUISwitcher : MonoBehaviour
{
    public GameObject keyboardHint;         // 키보드 안내 텍스트
    public GameObject gamepadHint;          // 게임패드 안내 텍스트
    // 가상 조이스틱 그룹 - Canvas Group의 Alpha로 숨김 (오브젝트는 끄지 않음)
    public CanvasGroup touchControls;

    PlayerInput playerInput;

    void OnEnable()
    {
        // Play 중 재컴파일 뒤에도 다시 채움
        if (playerInput == null) playerInput = GetComponent<PlayerInput>();
        playerInput.onControlsChanged += onControlsChanged; // 스킴이 바뀔 때
        InputSystem.onDeviceChange += onDeviceChange;       // 장치가 생기거나 사라질 때
    }

    void OnDisable()
    {
        if (playerInput != null) playerInput.onControlsChanged -= onControlsChanged;
        InputSystem.onDeviceChange -= onDeviceChange;
    }

    void Start() { Refresh(); }     // Player Input이 스킴을 정한 뒤 첫 갱신

    void onControlsChanged(PlayerInput input) { Refresh(); }
    void onDeviceChange(InputDevice device, InputDeviceChange change)
    {
        Refresh();
    }

    void Refresh()
    {
        // 재컴파일,Play 종료 중 비어 있거나 파괴된 참조 접근 방지
        if (playerInput == null || keyboardHint == null || gamepadHint == null || touchControls == null) return;
        string scheme = playerInput.currentControlScheme;
        // 폰, Touch Simulation이면 true, PC 빌드면 false
        bool hasTouch = Touchscreen.current != null;

        keyboardHint.SetActive(scheme == "Keyboard&Mouse");
        // 가상 스틱 드래그로 생기는 Gamepad에는 안 띄움
        gamepadHint.SetActive(scheme == "Gamepad" && !hasTouch);

        // 터치스크린 장치가 있으면 조작부를 항상 보인다 (스킴이 아니라 플랫폼으로 판단)
        touchControls.alpha = hasTouch ? 1f : 0f;
        touchControls.blocksRaycasts = hasTouch;
        touchControls.interactable = hasTouch;

        Debug.Log("활성 스킴: " + scheme + " / 터치스크린: " + hasTouch);
    }   
}
