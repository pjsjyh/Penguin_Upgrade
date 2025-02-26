using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;
public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    bool isGameStart = true;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        target = GameObject.Find("PenguinPlayer").GetComponent<Rigidbody2D>();

        if (GameManager.Instance == null)
        {
            Debug.LogError("❌ GameManager.Instance가 null입니다! 구독할 수 없음.");
        }
        else
        {
            GameManager.Instance.OnGameStartChanged += HandleGameStart;
        }

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameStart)
        {
            if (!isLive)
                return;
            Vector2 dirVec = target.position - rigid.position;
            Vector2 newVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + newVec);
            rigid.velocity = Vector2.zero;
        }
       
    }
    private void LateUpdate()
    {
        if (isGameStart)
        {
            if (!isLive)
                return;
            spriter.flipX = target.position.x < rigid.position.x;
        }
       
    }
    private void HandleGameStart(bool gameStarted)
    {
        isGameStart = gameStarted;
    }
    private void OnEnable()
    {
        if(GameManager.Instance.playerInstance)
            target = GameManager.Instance.playerInstance.GetComponent<Rigidbody2D>();
    }
}
