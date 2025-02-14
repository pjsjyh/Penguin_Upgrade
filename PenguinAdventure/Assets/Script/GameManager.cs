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
            // JSON ���ڿ��� roundWrapper�� ��ȯ
            roundWrapper wrapper = JsonUtility.FromJson<roundWrapper>(jsonFile.text);

            if (wrapper != null && wrapper.rounds != null)
            {
                round = wrapper.rounds;
                Debug.Log("JSON �ҷ����� ����! ���� ����: " + round.Length);
            }
            else
            {
                Debug.LogError("JSON �Ľ� ���� - �����Ͱ� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogError("JSON ������ ã�� �� �����ϴ�.");
        }
    }

}
