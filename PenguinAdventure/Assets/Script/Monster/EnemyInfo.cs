using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyInfo : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color targetColor = new Color(1.0f, 0.55f, 0.55f);
    public float Damage = 10f;
    public float Blood = 50f;
    public float ExperienceCapacity = 50;
    public float DamageMore = 10f;
    public float BloodMore = 5;
    public float ExperienceMore = 2;
    public GameObject experienceObj;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    public float DamageGet()
    {
        return Damage;
    }
    public void DamageSet(float dam)
    {
        Blood = Blood - dam;
        StartCoroutine(ChangeColorCoroutine());
        if (Blood < 0)
        {
            spriteRenderer.color = originalColor;
            Instantiate(experienceObj, gameObject.transform.position, Quaternion.identity);
            MonsterPoolManager.Instance.ReturnMonster(gameObject);
        }

    }
    private IEnumerator ChangeColorCoroutine()
    {
        spriteRenderer.color = targetColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("cndehf!!!TTT" + other.name);

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
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
            collision.gameObject.GetComponent<playerBlood>().getDamage(Damage);

        }
    }

}
