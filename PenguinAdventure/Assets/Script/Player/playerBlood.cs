using UnityEngine;
using PlayerInfoManager;
using UnityEngine.UI;
using System;
using TMPro;
using System.Collections;
public class playerBlood : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color targetColor = new Color(1.0f, 0.55f, 0.55f);

    float HPvalue = 100;
    public GameObject gameoverView;
    public Slider bloodSlider;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        HPvalue = Math.Max(100, PlayerManager.Instance.myPlayer._hp);
        bloodSlider.maxValue = HPvalue;
        bloodSlider.value = HPvalue;
        if (gameoverView == null)
        {
            gameoverView = GameObject.Find("GameOverView");
        }

    }
    public void GameResatart()
    {
        HPvalue = Math.Max(100, PlayerManager.Instance.myPlayer._hp);
        bloodSlider.maxValue = HPvalue;
        bloodSlider.value = HPvalue;
    }
    public void getDamage(float damage)
    {
        HPvalue -= damage;
        bloodSlider.value = HPvalue;
        if (gameoverView == null)
        {
            gameoverView = GameObject.Find("GameOverView");
        }
        if (HPvalue <= 0)
        {
            gameoverView.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>().text = GameObject.Find("GameManage").GetComponent<timerManager>().sumExp.ToString();
            WebGLFirebaseManager.Instance.SaveScore(PlayerManager.Instance.myPlayer._name, GameObject.Find("GameManage").GetComponent<timerManager>().sumExp);
            GameManager.Instance.IsGameStart = false;
            MonsterPoolManager.Instance.clearMonster();
            GameResatart();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("cndehf!!!TTT22");

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(ChangeColorCoroutine());
            // Debug.Log("cndehf!!!TTTEnemy22");
            if (other.GetComponent<EnemyInfo>())
                getDamage(other.GetComponent<EnemyInfo>().Damage);
            if (other.GetComponent<enemyBossSkill>())
                getDamage(other.GetComponent<enemyBossSkill>().Damage);


        }
    }
    private IEnumerator ChangeColorCoroutine()
    {
        spriteRenderer.color = targetColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
    // 일반 충돌 감지 (Trigger가 아닐 때)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("cndehf!!!CCCCC22");

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Debug.Log("cndehf!!!CCCCCEnemy22");
            if (collision.gameObject.GetComponent<EnemyInfo>())
                getDamage(collision.gameObject.GetComponent<EnemyInfo>().Damage);
            if (collision.gameObject.GetComponent<enemyBossSkill>())
                getDamage(collision.gameObject.GetComponent<enemyBossSkill>().Damage);

        }
    }
}
