using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roundSettingScript;
namespace WaveMonsterSpawnScript
{

    public class WaveMonsterSpawn : MonoBehaviour
    {
        public static WaveMonsterSpawn Instance;
        public List<GameObject> waveMonsterSpawn;

        public Transform[] spawnPoint;

        // Start is called before the first frame update
        void Awake()
        {
            if (Instance == null)
                Instance = this; // ✅ 싱글턴 인스턴스 저장
            else
                Destroy(gameObject); // ✅ 중복 방지

            spawnPoint = GetComponentsInChildren<Transform>();
            //spawn(0);
            //MonsterFactory.CreateMonster(0);
        }


        public void spawn(int num)
        {
            for (int i = 1; i < spawnPoint.Length; i++)
            {
                Instantiate(waveMonsterSpawn[num], spawnPoint[i].position, Quaternion.identity);
            }

        }
        public void SpawnWave(int level)
        {
            Debug.Log("WAVE " + level + " 몬스터 생성!");
            
            MonsterFactory.CreateMonster(level);
            //if (level % 4 == 0)
            //{
            //    // 4번째 웨이브마다 보스 등장
            //    MonsterFactory.CreateMonster(MonsterType.Boss, GetRandomSpawnPosition());
            //}
            //else
            //{
            //    // 일반 몬스터 등장
            //    for (int i = 0; i < level * 3; i++) // 웨이브 레벨이 올라갈수록 더 많은 몬스터 등장
            //    {
            //        MonsterType type = GetRandomMonsterType();
            //        MonsterFactory.CreateMonster(type, GetRandomSpawnPosition());
            //    }
            //}
        }
    }

}










