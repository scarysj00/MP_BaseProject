using UnityEngine;

public class EditorPlatformService : IPlatformService
{
    public string PlatformName => "Editor (Mock)";

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
        Debug.Log($"[Mock] 저장 {key} = {value}");
    }

    public string LoadString(string key, string defaultValue) => PlayerPrefs.GetString(key, defaultValue);

    public void Vibrate(int ms)         => Debug.Log($"[Mock] 진동 {ms}ms");
    public void ShowMessage(string t)   => Debug.Log($"[Mock] 메시지: {t}");
    public void Share(string t)         => Debug.Log($"[Mock] 공유: {t}");
    public void Purchase(string id)         => Debug.Log($"[Mock] 구매: {id}");
}
