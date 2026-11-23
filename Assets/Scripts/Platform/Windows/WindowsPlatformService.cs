using System.IO;
using UnityEngine;

public class WindowsPlatformService : IPlatformService
{
    public string PlatformName => "Windows";

    // Windows는 파일 시스템을 자유롭게 쓴다.
    string PathFor(string key) => Path.Combine(Application.persistentDataPath, key + ".txt");

    public void SaveString(string key, string value) => File.WriteAllText(PathFor(key), value);

    public string LoadString(string key, string defaultValue) => File.Exists(PathFor(key)) ? File.ReadAllText(PathFor(key)) : defaultValue;

    public void Vibrate(int ms) { /*데스크톱은 진동 없음 - 조용히 무시 */ }
    public void ShowMessage(string t) => Debug.Log("[Windows] " + t);
    public void Share(string t) => GUIUtility.systemCopyBuffer = t; // 클립보드 복사
    public void Purchase(string id) => Debug.Log("[Windows] 결제 미구현" + id);

}
