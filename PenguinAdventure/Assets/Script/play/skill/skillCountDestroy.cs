using System.Collections;
using System.Collections.Generic;
using PlayerInfoManager;
using UnityEngine;

public class skillCountDestroy : MonoBehaviour
{
    float timer;
    SpriteRenderer spriter;
    Rigidbody2D rigid;
    public Rigidbody2D target;


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        target = GameObject.Find("PenguinPlayer").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            Destroy(gameObject);
        }
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
            // Debug.Log("cndehf!!!CCCCCEnemyPlayer");
            // collision.gameObject.GetComponent<playerBlood>().getDamage(Damage);

        }
    }

}
