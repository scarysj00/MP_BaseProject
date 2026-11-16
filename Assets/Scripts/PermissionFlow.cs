using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class PermissionFlow : MonoBehaviour
{
    public GameObject rationalePanel;       // "왜 필요한가" 설명 패널
    public GameObject settingsPanel;        // "설정에서 켜주세요" 패널

    public void RequestCamera()
    {
#if UNITY_ANDROID
        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Debug.Log("이미 허용됨");
            return;
        }        
        // 이전에 거부한 적 있으면 이유를 먼저 설명
        if (Permission.ShouldShowRequestPermissionRationale(Permission.Camera))
        {
            rationalePanel.SetActive(true);
            return;
        }
        DoRequest();
#else 
        Debug.Log("이 플랫폼은 런타임 권한이 없음");
#endif       
    }

    public void DoRequest()
    {
        rationalePanel.SetActive(false);    // 설명 패널을 닫고 시스템 팝업으로
#if UNITY_ANDROID
        var cb = new PermissionCallbacks();
        cb.PermissionGranted += _ => Debug.Log("허용");
        cb.PermissionDenied += _ =>
        {
            // 거부 직후 "이유를 보여줄 필요가 없다"고 답하면 더는 팝업을 띄울 수 없는 영구 거부 상태
            if (Permission.ShouldShowRequestPermissionRationale(Permission.Camera)) Debug.Log("거부");
            else settingsPanel.SetActive(true);
        };
        Permission.RequestUserPermission(Permission.Camera, cb);
#endif
    }
}
