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

    public GameObject panel;          // 버튼을 추가할 Panel
    public GameObject panel2;          // 버튼을 추가할 Panel
    public GameObject buttonPrefab;   // 버튼 프리팹

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
            GenerateButtons(); // 패널이 비어 있을 때만 버튼 재생성
        }
    }
    private void OnEnable()
    {
        if (panel.transform.childCount == 0)
        {
            GenerateButtons(); // 패널이 비어 있을 때만 버튼 재생성
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
        // UI 요소가 연결되었다면 텍스트와 이미지를 설정
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
        // 기존 버튼이 있으면 모두 삭제
        if (panel.transform.childCount == 0)
        {

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

    private void OnPassiveButtonClick(PassiveInfo clickedPassive)
    {
        // PassiveManager.Instance.SetSelectedPassive(clickedPassive);
    }

}

