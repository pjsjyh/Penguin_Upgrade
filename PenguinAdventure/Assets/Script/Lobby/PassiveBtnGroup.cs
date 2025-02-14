using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PassiceInfoScript;
using PlayerInfoManager;
public class PassiveBtnGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;          // ��ư�� �߰��� Panel
    public GameObject buttonPrefab;   // ��ư ������

    public List<PassiveInfo> passiveList = new List<PassiveInfo>();

    public void GenerateButtons()
    {

        // ���� ��ư�� ������ ��� ����
        for (int i = panel.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(panel.transform.GetChild(i).gameObject);
        }

        // passiveList���� �� �ɷ� �����͸� ��ư�� ����
        foreach (var ability in PlayerManager.Instance.passiveList)
        {
            GameObject newButton = Instantiate(buttonPrefab, panel.transform);
            newButton.name = ability.title;
            Passive p = newButton.GetComponent<Passive>();

            if (p != null)
            {
                p.SetData(ability);  // SetData ȣ�� �� PassiveInfo Ÿ���� ����
            }
            else
            {
                Debug.LogError("Passive ������Ʈ�� ã�� �� �����ϴ�.");
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
                Debug.LogError("JSON �Ľ� ���� - JSON �迭�� ��ȯ�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("JSON ������ ã�� �� �����ϴ�.");
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