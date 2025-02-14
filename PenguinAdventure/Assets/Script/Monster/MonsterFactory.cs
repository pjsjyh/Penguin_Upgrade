using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roundSettingScript;
using WaveMonsterSpawnScript;
public enum MonsterType
{
    Bottle, Cigarette, Factory, Mask, Oil, Paper, PlasticBottle, PotatoBag, Rradioactivity, Strow,
}
public class MonsterFactory
{

    public static void CreateMonster(int getlevel)
    {
        WaveMonsterSpawn waveSpawner = GameObject.FindObjectOfType<WaveMonsterSpawn>(); // ✅ 인스턴스 찾기
        if (waveSpawner == null)
        {
            Debug.LogError("WaveMonsterSpawn을 찾을 수 없습니다.");
            return;
        }

        roundSetting round = GameManager.Instance.round[getlevel];

        if (round != null)
        {
            if (round.roundType == "normal")
            {
                for (int i = 0; i < round.monsterNum; i++)
                {
                    int random = Random.Range(0, round.monsterList.Length);
                    string monsterName = round.monsterList[random];

                    GameObject monsterPrefab = Resources.Load<GameObject>("Prefab/Monster/" + monsterName);
                    if (monsterPrefab == null)
                    {
                        Debug.LogError($"몬스터 프리팹을 찾을 수 없음: {monsterName}");
                        continue;
                    }

                    // ✅ `waveSpawner.spawnPoint` 사용하여 위치 가져오기
                    Vector2 spawnPosition = waveSpawner.spawnPoint[i % waveSpawner.spawnPoint.Length+1].position;
                    GameObject monsterInstance = Object.Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
                    monsterInstance.name = monsterName;
                }
            }
            else if(round.roundType == "boss")
            {
                int random = Random.Range(0, round.monsterList.Length);
                string monsterName = round.monsterList[random];

                GameObject monsterPrefab = Resources.Load<GameObject>("Prefab/Monster/" + monsterName);
                if (monsterPrefab != null)
                {
                    int rando2m = Random.Range(1, waveSpawner.spawnPoint.Length);
                    // ✅ `waveSpawner.spawnPoint` 사용하여 위치 가져오기
                    Vector2 spawnPosition = waveSpawner.spawnPoint[rando2m].position;
                    GameObject monsterInstance = Object.Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
                    monsterInstance.name = monsterName;
                }

               
            }
            
        }
        else
        {
            Debug.LogError($"등록되지 않은 몬스터 타입:");
        }
    }
}
