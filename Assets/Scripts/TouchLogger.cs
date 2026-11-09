using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchLogger : MonoBehaviour
{
    void OnEnable() { EnhancedTouchSupport.Enable(); }
    void OnDisable() { EnhancedTouchSupport.Disable(); }

    // Update is called once per frame
    void Update()
    {
        foreach (var t in Touch.activeTouches) Debug.Log($"터치 {t.screenPosition} 상태 {t.phase}");
    }
}
