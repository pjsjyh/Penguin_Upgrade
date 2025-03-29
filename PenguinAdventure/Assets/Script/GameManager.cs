using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;
using roundSettingScript;
using System;
using Firebase;
using Firebase.Extensions;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Player player;
    public GameObject playerPrefab;
    public roundSetting[] round;
    public GameObject playerInstance;
 
    public bool _isGameStart = false;
    public event Action<bool> OnGameStartChanged;
    public string playerAddress = "Prefab/PenguinPlayer";

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
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                Debug.Log("✅ Firebase 초기화 완료");
                // Firebase 기능 사용 가능!
            }
            else
            {
                Debug.LogError($"❌ Firebase 초기화 실패: {task.Result}");
            }
        });
    }
    IEnumerator GameStartRoutine()
    {
        CreatePlayer();
        yield return new WaitForSeconds(1f);
        MonsterPoolManager.Instance.StartMakeMonster(2);
    }
    void CreatePlayer()
    {
        if (playerPrefab != null)
        {
            Addressables.LoadAssetAsync<GameObject>(playerAddress).Completed += OnPlayerLoaded;
            //playerInstance = Instantiate(playerPrefab);
            //playerInstance.name = "PenguinPlayer";
           // playerInstance.transform.position = new Vector3(0, 0, 0);
           
        }
    }
    void OnPlayerLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject playerPrefab = handle.Result;
            playerInstance = Instantiate(playerPrefab);
            playerInstance.name = "PenguinPlayer";
            player = playerInstance.GetComponent<Player>();
            DontDestroyOnLoad(playerInstance);
        }
        else
        {
            Debug.LogError("❌ Player prefab load failed: " + handle.OperationException);
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
                //Debug.Log("JSON 불러오기 성공! 라운드 개수: " + round.Length);
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
