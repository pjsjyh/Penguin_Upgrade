using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBossSkill : MonoBehaviour
{
    public float Damage = 15f;

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
        if (other.CompareTag("Player"))
        {
            // Debug.Log("cndehf!!!TTTEnemyPlayer");
            other.GetComponent<playerBlood>().getDamage(Damage);

        }
    }

    // 일반 충돌 감지 (Trigger가 아닐 때)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("cndehf!!!CCCCC" + collision.gameObject.name);

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
            // Debug.Log("cndehf!!!CCCCCEnemyPlayer");
            collision.gameObject.GetComponent<playerBlood>().getDamage(Damage);

        }
    }
}
