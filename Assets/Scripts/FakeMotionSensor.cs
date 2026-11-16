using UnityEngine;

// 실기기가 없을 때 쓰는 가짜 센서. Inspector 슬라이더로 기울기를 손으로 준다.
public class FakeMotionSensor : MonoBehaviour, IMotionSensor
{
    [Range(-1f, 1f)] public float tiltX;
    [Range(-1f, 1f)] public float tiltY;

    public Vector2 GetTilt() => new Vector2(tiltX, tiltY);
    public bool IsAvailable => true;
}