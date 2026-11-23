// 게임 로직이 플랫폼에게 요구하는 "약속". 어떻게 하는지는 구현체가 정한다.
public interface IPlatformService
{
    string PlatformName { get; }

    // 저장소
    void SaveString(string key, string value);
    string LoadString(string key, string defaultValue);

    // 기기 기능
    void Vibrate(int milliseconds);
    void ShowMessage(string text);  // Toast / alert / 로그
    void Share(string text);

    // 결제 (지금은 약속만 해둔다)
    void Purchase(string productId);
}