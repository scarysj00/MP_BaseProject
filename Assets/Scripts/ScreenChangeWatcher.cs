using UnityEngine;

public class ScreenChangeWatcher : MonoBehaviour
{
    int lastW, lastH;

    void Start()
    {
        lastW = Screen.width;
        lastH = Screen.height;
    }

    void Update()
    {
        if (Screen.width != lastW || Screen.height != lastH)
        {
            lastW = Screen.width;
            lastH = Screen.height;
            Debug.Log($"화면 크기 변경: {lastW} x {lastH} (비율 {(float)lastW / lastH:F2})");
            // 화면비에 따라 다시 계산할 것이 있으면 여기서 처리한다
        }
    }
}
