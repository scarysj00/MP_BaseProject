using UnityEngine;
using UnityEngine.InputSystem;

// 진짜 가속도계를 읽는 구현체. 노이즈를 줄이려고 이전 값과 섞는다.
public class DeviceMotionSensor : MonoBehaviour, IMotionSensor
{
    [Range(0f, 1f)] public float smoothing = 0.1f;
    Vector2 filtered;

    public bool IsAvailable => Accelerometer.current != null;

    void OnEnable()
    {
        if (Accelerometer.current != null) InputSystem.EnableDevice(Accelerometer.current);
    }

    public Vector2 GetTilt()
    {
        if (!IsAvailable) return Vector2.zero;
        Vector3 a = Accelerometer.current.acceleration.ReadValue();
        Vector2 raw = new Vector2(a.x, a.y);
        // 저역 통과 필터 : 새 값을 smoothing 만큼만 반영
        filtered = Vector2.Lerp(filtered, raw, smoothing);
        return filtered;
    }
}