using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text scoreText;
    int score;

    const string ScoreKey = "score";

    void Awake() 
    { 
        Instance = this; 
        score = PlayerPrefs.GetInt(ScoreKey, 0);    // 지난 점수 복원
        RefreshUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        RefreshUI();
    }

    void RefreshUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    // 백그라운드로 갈 때 (pause == true) 저장
    void OnApplicationPause(bool pause)
    {
        if (pause) Save();
    }

    // 데스크톱에서 포커스를 잃을 때도 저장
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) Save();
    }

    void OnApplicationQuit() { Save(); }

    void Save()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
        Debug.Log("저장됨: " + score);
    }
}
