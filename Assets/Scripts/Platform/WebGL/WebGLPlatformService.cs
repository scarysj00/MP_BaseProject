using System.Runtime.InteropServices;
using UnityEngine;

public class WebGLPlatformService : IPlatformService
{
    // .jslib의 함수를 C#에 선언. 이름이 정확히 같아야 한다.
    [DllImport("__Internal")] static extern void Browser_Alert(string text);
    [DllImport("__Internal")] static extern void Browser_CopyToClipboard(string text);
    [DllImport("__Internal")] static extern void Browser_Vibrate(int ms);

    public string PlatformName => "WebGL";

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save(); // WebGL에서는 이게 IndexDB 플러시를 유도한다.
    }

    public string LoadString(string key, string d) => PlayerPrefs.GetString(key, d);

    public void Vibrate(int ms)         => Browser_Vibrate(ms);
    public void ShowMessage(string t)   => Browser_Alert(t);
    public void Share(string t)         => Browser_CopyToClipboard(t);
    public void Purchase(string id)         => Debug.Log("[WebGL] 결제 미구현: " + id);

}
