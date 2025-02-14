using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;

public class penguinFriendsSkillDill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("cndehf!!!TTT" + other.name);

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Enemy"))
        {
            // Debug.Log("cndehf!!!TTTEnemyPlayer");
            if (other.GetComponent<EnemyInfo>())
                other.GetComponent<EnemyInfo>().DamageSet(20f + (PlayerManager.Instance.myPlayer._damage / 10));


            // other.GetComponent<playerBlood>().getDamage(Damage);

        }
    }

    // 일반 충돌 감지 (Trigger가 아닐 때)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("cndehf!!!CCCCC" + collision.gameObject.name);

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (collision.gameObject.GetComponent<EnemyInfo>())
                collision.gameObject.GetComponent<EnemyInfo>().DamageSet(20f + (PlayerManager.Instance.myPlayer._damage / 10));
            // Debug.Log("cndehf!!!CCCCCEnemyPlayer");
            // collision.gameObject.GetComponent<playerBlood>().getDamage(Damage);

        }
    }

}
