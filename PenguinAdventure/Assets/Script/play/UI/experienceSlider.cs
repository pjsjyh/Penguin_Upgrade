using UnityEngine.UI;
using UnityEngine;

public class experienceSlider : MonoBehaviour
{
    public Slider progressSlider;  // Slider 오브젝트를 연결하세요
    public GameObject SelectSkillUI; // 패널 오브젝트를 연결하세요

    void Start()
    {
        SelectSkillUI.SetActive(false);  // 시작 시 패널 비활성화
    }

    void Update()
    {
        // Slider 값이 100에 도달하면 패널 표시
        if (progressSlider.value >= 100)
        {
            SelectSkillUI.SetActive(true);  // 패널 활성화
            Time.timeScale = 0f;       // 게임 일시 정지
        }
    }

    public void clickedSkillBtn()
    {
        SelectSkillUI.SetActive(false);  // 시작 시 패널 비활성화
        progressSlider.value = 0;
        Time.timeScale = 1f;       // 게임 재개
    }
}
