using UnityEngine;

// "기울기를 돌려준다"는 약속만 정한다. 어떻게 재는지는 구현체가 정한다.
public interface IMotionSensor
{
    // x: 좌우 기울기(-1~1), y: 앞뒤 기울기(~1-1)
    Vector2 GetTilt();
    bool IsAvailable { get; }
} 
