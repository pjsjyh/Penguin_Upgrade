using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerEat : MonoBehaviour
{
    public float experience = 10;
    public AudioSource clip;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("cndehf!!!TTT" + other.name);

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
            // Debug.Log("EATcndehf!!!TTTEnemyPlayer");

            GameObject.Find("experiencebarSlider").GetComponent<Slider>().value += experience;
            GameObject.Find("GameManage").GetComponent<timerManager>().sumex(experience);
            // if (clip != null)
            //     clip.Play();
            Destroy(gameObject);
            // other.GetComponent<playerBlood>().getDamage(Damage);

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
            // collision.gameObject.GetComponent<playerBlood>().getDamage(Damage);

        }
    }
}
