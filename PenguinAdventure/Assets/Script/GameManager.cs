using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;
using roundSettingScript;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PoolManager poolmanager;
    public Player player;

    public roundSetting[] round;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadSettings();
        }
        else
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }
      

    }

    void LoadSettings()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Round");

        if (jsonFile != null)
        {
            // JSON 문자열을 roundWrapper로 변환
            roundWrapper wrapper = JsonUtility.FromJson<roundWrapper>(jsonFile.text);

            if (wrapper != null && wrapper.rounds != null)
            {
                round = wrapper.rounds;
                Debug.Log("JSON 불러오기 성공! 라운드 개수: " + round.Length);
            }
            else
            {
                Debug.LogError("JSON 파싱 실패 - 데이터가 없습니다.");
            }
        }
        else
        {
            Debug.LogError("JSON 파일을 찾을 수 없습니다.");
        }
    }

}
