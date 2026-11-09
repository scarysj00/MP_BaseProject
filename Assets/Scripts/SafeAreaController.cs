using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeAreaController : MonoBehaviour
{
    RectTransform rect;
    Rect lastSafeArea;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        Apply();
    }

    void Update()
    {
        // 화면 회전·기기 변경으로 안전 영역이 바뀌면 다시 적용 (폴링)
        if (Screen.safeArea != lastSafeArea) Apply();
    }

    void Apply()
    {
        Rect safe = Screen.safeArea;
        lastSafeArea = safe;

        // 안전 영역의 픽셀 좌표를 0~1 비율로 바꿔 앵커에 넣는다
        Vector2 min = safe.position;
        Vector2 max = safe.position + safe.size;
        min.x /= Screen.width;  min.y /= Screen.height;
        max.x /= Screen.width;  max.y /= Screen.height;

        rect.anchorMin = min;
        rect.anchorMax = max;
    }
}
