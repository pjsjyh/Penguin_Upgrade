using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MonsterPoolManager : MonoBehaviour
{
    public static MonsterPoolManager Instance; 
    public List<GameObject> monsterPrefabs; 
    private Dictionary<string, Queue<GameObject>> monsterPools = new Dictionary<string, Queue<GameObject>>();
    private List<GameObject> activeMonsters = new List<GameObject>();

    public List<string> monsterKeys;
    private Dictionary<string, GameObject> prefabCache = new();
    public bool ismakeFinish = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            //InitializePools(20); //  각 몬스터 20개씩 생성
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartMakeMonster(int n)
    {
        StartCoroutine(InitializePools(n));
    }
    public IEnumerator InitializePools(int size)
    {
        foreach (string key in monsterKeys)
        {
            if (!monsterPools.ContainsKey(key))
                monsterPools[key] = new Queue<GameObject>();

            var handle = Addressables.LoadAssetAsync<GameObject>(key);
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject prefab = handle.Result;
                prefabCache[key] = prefab;

                for (int i = 0; i < size; i++)
                {
                    GameObject monster = Instantiate(prefab);
                    monster.SetActive(false);
                    monster.transform.SetParent(this.transform, false);
                    monsterPools[key].Enqueue(monster);
                }
            }
            else
            {
                Debug.LogError($"[{key}] Addressables 로드 실패");
            }
        }
        ismakeFinish = true;
    }
    public GameObject GetMonster(string monsterKey, Vector2 spawnPosition)
    {
        monsterKey = "Prefab/Monster/" + monsterKey;
        if (!monsterPools.ContainsKey(monsterKey))
        {
            monsterPools[monsterKey] = new Queue<GameObject>(); // 풀 초기화
        }

        if (monsterPools[monsterKey].Count > 0)
        {
            GameObject monster = monsterPools[monsterKey].Dequeue();
            monster.transform.position = spawnPosition;
            monster.SetActive(true);
            activeMonsters.Add(monster);
            return monster;
        }
        // 풀에 남아있는 몬스터가 없으면 새로 생성하고 풀에 추가
        if (prefabCache.TryGetValue(monsterKey, out GameObject prefab))
        {
            GameObject newMonster = Instantiate(prefab, spawnPosition, Quaternion.identity);
            newMonster.SetActive(true);
            activeMonsters.Add(newMonster);
            return newMonster;
        }
        return null;
    }

    public void ReturnMonster(GameObject monster)
    {
        monster.SetActive(false);
        string key = monster.name.Replace("(Clone)", "").Trim();

        if (!monsterPools.ContainsKey(key))
            monsterPools[key] = new Queue<GameObject>();

        monsterPools[key].Enqueue(monster);

    }
    public void clearMonster()
    {
        foreach (GameObject monster in activeMonsters)
        {
            string key = monster.name.Replace("(Clone)", "").Trim();

            if (!monsterPools.ContainsKey(key))
                monsterPools[key] = new Queue<GameObject>();

            monsterPools[key].Enqueue(monster);
        }
        activeMonsters.Clear();
    }

}
