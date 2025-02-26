using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;
using roundSettingScript;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Player player;
    public GameObject playerPrefab;
    public roundSetting[] round;
    public GameObject playerInstance;
 
    public bool _isGameStart = false;
    public event Action<bool> OnGameStartChanged;


    public bool IsGameStart
    {
        get => _isGameStart;
        set
        {
            if (_isGameStart != value) // ✅ 값이 변경될 때만 실행
            {
                _isGameStart = value;
                Debug.Log($"🎮 게임 상태 변경: {_isGameStart}");

                OnGameStartChanged?.Invoke(_isGameStart);
            }
        }
    }
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
    void Start()
    {
       
        StartCoroutine(GameStartRoutine());
    }
    IEnumerator GameStartRoutine()
    {
        CreatePlayer();
        yield return new WaitForSeconds(1f);
        MonsterPoolManager.Instance.InitializePools(20);
    }
    void CreatePlayer()
    {
        if (playerPrefab != null)
        {
            playerInstance = Instantiate(playerPrefab);
            playerInstance.name = "PenguinPlayer";
           // playerInstance.transform.position = new Vector3(0, 0, 0);
            player = playerInstance.GetComponent<Player>();
            DontDestroyOnLoad(playerInstance);
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
