using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PassiceInfoScript;
using PlayerInfoManager;
public class PassiveBtnGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;          // 버튼을 추가할 Panel
    public GameObject buttonPrefab;   // 버튼 프리팹

    public List<PassiveInfo> passiveList = new List<PassiveInfo>();

    public void GenerateButtons()
    {

        // 기존 버튼이 있으면 모두 삭제
        for (int i = panel.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(panel.transform.GetChild(i).gameObject);
        }

        // passiveList에서 각 능력 데이터를 버튼에 설정
        foreach (var ability in PlayerManager.Instance.passiveList)
        {
            GameObject newButton = Instantiate(buttonPrefab, panel.transform);
            newButton.name = ability.title;
            Passive p = newButton.GetComponent<Passive>();

            if (p != null)
            {
                p.SetData(ability);  // SetData 호출 시 PassiveInfo 타입을 전달
            }
            else
            {
                Debug.LogError("Passive 컴포넌트를 찾을 수 없습니다.");
            }
        }
    }

    void LoadSettings()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("PassiveInfo");

        if (jsonFile != null)
        {
            string wrappedArray = WrapArray(jsonFile.text);

            PassiveInfo[] abilitiesArray = JsonUtility.FromJson<PassiveArrayWrapper>(wrappedArray).passives;

            if (abilitiesArray != null)
            {
                PlayerManager.Instance.passiveList.AddRange(abilitiesArray);
            }
            else
            {
                Debug.LogError("JSON 파싱 실패 - JSON 배열을 변환할 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("JSON 파일을 찾을 수 없습니다.");
        }
    }

    private string WrapArray(string jsonArray)
    {
        return "{ \"passives\": " + jsonArray + "}";
    }

    [System.Serializable]
    private class PassiveArrayWrapper
    {
        public PassiveInfo[] passives;
    }

}