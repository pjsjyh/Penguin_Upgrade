using UnityEngine;
using UnityEngine.UIElements;

public class SkillPanelController : MonoBehaviour
{
    private Button skill1Element;
    private Button skill2Element;
    private Button skill3Element;
    public GameObject SkillPanel;
    public GameObject SkillPanelUI;

    void start()
    {
        // UI Document에서 RootVisualElement 가져오기
        var root = GetComponent<UIDocument>().rootVisualElement;

        // UXML에서 정의한 Skill1 요소와 panelElement 요소 찾기
        skill1Element = root.Q<Button>("Skill1");
        skill2Element = root.Q<Button>("Skill2");
        skill3Element = root.Q<Button>("Skill3");

        // Skill1 요소에 클릭 이벤트 추가
        skill1Element.clicked += TogglePanelVisibility;
        skill2Element.clicked += TogglePanelVisibility;
        skill3Element.clicked += TogglePanelVisibility;

        Debug.Log(skill1Element);
    }

    private void TogglePanelVisibility()
    {
        // panelElement의 visible 속성을 false로 설정해 패널을 비활성화
        SkillPanel.SetActive(false);
        SkillPanelUI.SetActive(false);

        Debug.Log("dd");
    }
}
