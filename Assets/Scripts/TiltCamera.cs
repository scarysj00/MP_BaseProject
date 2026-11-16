using UnityEngine;

// 기울기로 카메라를 살짝 회전. 어느 센서인지 모른다. - 인터페이스만 본다.
public class TiltCamera : MonoBehaviour
{
    public MonoBehaviour sensorSource;  // Fake 또는 Device 둘 중 하나를 끌어넣는다.
    public float maxAngle = 10f;

    IMotionSensor sensor;

    void Awake() { sensor = sensorSource as IMotionSensor; }

    void LateUpdate()
    {
        if (sensor == null || !sensor.IsAvailable) return;
        Vector2 tilt = sensor.GetTilt();
        transform.localRotation = Quaternion.Euler(-tilt.y * maxAngle, tilt.x * maxAngle, 0f);
    }
}