using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PassiceInfoScript;
using PlayerInfoManager;
public class PassiveManager : MonoBehaviour
{
    public static PassiveManager Instance { get; private set; }

    public GameObject panel;          // ��ư�� �߰��� Panel
    public GameObject panel2;          // ��ư�� �߰��� Panel
    public GameObject buttonPrefab;   // ��ư ������

    public List<PassiveInfo> passiveList = new List<PassiveInfo>();

    public TextMeshProUGUI passiveText;
    public TextMeshProUGUI passiveTextLevel;
    public TextMeshProUGUI passiveDiscription;
    public RawImage passiveImg;

    private GameObject dontDestroyOnLoadGroup;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetSelectedPassive(PlayerManager.Instance.SelectedPassive);
            LoadSettings();
            GenerateButtons();


        }
        else
        {
            Destroy(gameObject);
        }
        if (panel.transform.childCount == 0)
        {
            GenerateButtons(); // �г��� ��� ���� ���� ��ư �����
        }
    }
    private void OnEnable()
    {
        if (panel.transform.childCount == 0)
        {
            GenerateButtons(); // �г��� ��� ���� ���� ��ư �����
        }
    }
    private void FindUIElements()
    {
        passiveImg = GameObject.Find("SelectPassiveImg").GetComponent<RawImage>();
        passiveText = GameObject.Find("SelectPassiveText").GetComponent<TextMeshProUGUI>();
        passiveTextLevel = GameObject.Find("SelectPassiveLevel").GetComponent<TextMeshProUGUI>();
        passiveDiscription = GameObject.Find("SelectPassiveDiscription").GetComponent<TextMeshProUGUI>();
    }
    public void SetSelectedPassive(PassiveInfo passiveInfo)
    {
        if (passiveText == null || passiveDiscription == null || passiveTextLevel == null || passiveImg == null)
        {
            FindUIElements();
        }

        PlayerManager.Instance.SelectedPassive = passiveInfo;

        // UI ��Ұ� ����Ǿ��ٸ� �ؽ�Ʈ�� �̹����� ����
        if (passiveText != null && passiveDiscription != null && passiveTextLevel != null && passiveImg != null&& PlayerManager.Instance.SelectedPassive.title!=null)
        {
            PassiveInfo p = PlayerManager.Instance.SelectedPassive;
            passiveText.text =p.title;
            passiveDiscription.text =p.discription;
            string modifiedText = p.discription.Replace("n",p.abilities[p.nowLevel-1].duration.ToString());
            passiveDiscription.text = modifiedText;

            passiveTextLevel.text = "LV" + PlayerManager.Instance.SelectedPassive.nowLevel;

            Texture2D texture = Resources.Load<Texture2D>(PlayerManager.Instance.SelectedPassive.imgSource);
            if (texture != null)
            {
                passiveImg.texture = texture;
            }
        }
    }
   
    public void GenerateButtons()
    {
        // ���� ��ư�� ������ ��� ����
        if (panel.transform.childCount == 0)
        {

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

    private void OnPassiveButtonClick(PassiveInfo clickedPassive)
    {
        // PassiveManager.Instance.SetSelectedPassive(clickedPassive);
    }

}

