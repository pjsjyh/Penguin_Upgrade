using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;

public class particleColusion : MonoBehaviour
{
    public float damae = 20f;
    //파티클이 충돌하면 몬스터한테 데미지를 입힘
    // 충돌 시 작동할 함수
    void DoSomething()
    {
        Debug.Log("Particle collided with sun!");
        // 여기에 원하는 동작을 추가
    }

    // 파티클이 다른 오브젝트와 충돌할 때 호출
    void OnParticleCollision(GameObject other)
    {
        // Debug.Log("cndehf!!!");
        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Enemy"))
        {
            DoSomething();
        }
    }
    // Trigger 충돌 감지
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("cndehf!!!TTT");

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Enemy"))
        {
            // Debug.Log("cndehf!!!TTTEnemyPlayer");
            if (other.GetComponent<EnemyInfo>())
                other.GetComponent<EnemyInfo>().DamageSet(damae + (PlayerManager.Instance.myPlayer._damage / 10));

        }
    }

    // 일반 충돌 감지 (Trigger가 아닐 때)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("cndehf!!!CCCCC");

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<EnemyInfo>())
                collision.gameObject.GetComponent<EnemyInfo>().DamageSet(damae + (PlayerManager.Instance.myPlayer._damage / 10));
        }
    }
}
