using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackStackManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject quitPanel;

    readonly Stack<GameObject> openPanels = new Stack<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // Android 뒤로가기 = Escape 키. PC에서도 Esc로 같은 동작
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) OnBack();
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        openPanels.Push(panel);
    }

    public void OnBack()
    {
         if (openPanels.Count > 0)
        {
            var top = openPanels.Pop();     // 맨 위 패널부터 닫는다.
            top.SetActive(false);
        }
        else
        {
            OpenPanel(quitPanel);           // 다 닫혔을 때만 종료 확인
        }
    }

    public void ConfirmQuit() { Application.Quit(); }
   
}
