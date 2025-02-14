using UnityEngine;

public class pauseBtn : MonoBehaviour
{
    public GameObject pausePanel;  // 일시정지 패널을 드래그하여 연결하세요.
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;       // 게임 재개
            pausePanel.SetActive(false); // 패널 비활성화
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;       // 게임 일시 정지
            pausePanel.SetActive(true);  // 패널 활성화
            isPaused = true;
        }
    }
}
