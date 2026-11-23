using UnityEngine;

public class AndroidPlatformService : IPlatformService
{
    public string PlatformName => "Android";

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save(); 
    }
    public string LoadString(string key, string d) => PlayerPrefs.GetString(key, d);

    public void Vibrate(int ms) => Handheld.Vibrate();  // Unity 기본 진동 (길이 조절 불가)

    // Unity에 없는 Android Toast를 Java로 직접 호출
    public void ShowMessage(string text)
    {
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        // UI는 반드시 Android UI 스레드에서 만져야 한다.
        activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            // 이 블록은 조금 뒤 UI 스레드에서 실행된다. 여기서 쓰고, 여기서 정리한다.
            using (var toastClass = new AndroidJavaClass("android.widget.Toast"))
            using (var toast = toastClass.CallStatic<AndroidJavaObject>("makeText", activity, text, 0 /* LENGTH_SHORT */))
            {
                toast.Call("show");
            }
            activity.Dispose();
            unityPlayer.Dispose();
        }));
    }

    public void Share(string text)
    {
        using (var intentClass = new AndroidJavaClass("android.content.Intent"))
        using (var intent = new AndroidJavaObject("android.content.Intent"))
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        {
            intent.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            intent.Call<AndroidJavaObject>("setType", "text/plain");
            intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), text);
            intent.Call("startActivity", intent);
        }
    }
    public void Purchase(string id) => Debug.Log("[Android] 결제 미구현: " + id);
}
