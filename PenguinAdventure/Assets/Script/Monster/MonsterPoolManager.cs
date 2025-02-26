using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoolManager : MonoBehaviour
{
    public static MonsterPoolManager Instance; 
    public List<GameObject> monsterPrefabs; 
    private Dictionary<string, Queue<GameObject>> monsterPools = new Dictionary<string, Queue<GameObject>>();
    private List<GameObject> activeMonsters = new List<GameObject>();

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

    public void InitializePools(int size)
    {
        foreach (GameObject prefab in monsterPrefabs)
        {
            string key = prefab.name;
            if (!monsterPools.ContainsKey(key))
            {
                monsterPools[key] = new Queue<GameObject>();
            }

            for (int i = 0; i < size; i++)
            {
                GameObject makemonster = Instantiate(prefab);
                makemonster.SetActive(false);
                makemonster.transform.SetParent(this.transform, false);
                monsterPools[key].Enqueue(makemonster);
            }
        }
        ismakeFinish = true;
    }
    public GameObject GetMonster(string monsterName, Vector2 spawnPosition)
    {
        if (!monsterPools.ContainsKey(monsterName))
        {
            monsterPools[monsterName] = new Queue<GameObject>(); // ✅ 풀 초기화
        }

        if (monsterPools[monsterName].Count > 0)
        {
            GameObject monster = monsterPools[monsterName].Dequeue();
            monster.transform.position = spawnPosition;
            monster.SetActive(true);
            activeMonsters.Add(monster);
            return monster;
        }
        // ✅ 풀에 남아있는 몬스터가 없으면 새로 생성하고 풀에 추가
        GameObject newMonster = Instantiate(monsterPrefabs.Find(m => m.name == monsterName), spawnPosition, Quaternion.identity);
        newMonster.SetActive(true);
        activeMonsters.Add(newMonster);
        monsterPools[monsterName].Enqueue(newMonster); // ✅ 풀에 추가!

        return newMonster;
    }

    public void ReturnMonster(GameObject monster)
    {
        monster.SetActive(false);
        string key = monster.name;
        if (!monsterPools.ContainsKey(key))
        {
            monsterPools[key] = new Queue<GameObject>();
        }
        monsterPools[key].Enqueue(monster);
        
    }
    public void clearMonster()
    {
        foreach (GameObject monster in activeMonsters)
        {
            monster.SetActive(false); // ✅ 몬스터 비활성화
            monsterPools[monster.name].Enqueue(monster); // ✅ 다시 풀에 추가
        }
        activeMonsters.Clear();
    }
}
