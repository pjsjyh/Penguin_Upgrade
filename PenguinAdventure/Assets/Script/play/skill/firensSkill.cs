using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class firensSkill : MonoBehaviour
{

    public Transform[] spawnPoint;
    public Transform[] spawnPointLeft;
    public Transform[] spawnPointRight;

    float timer = 0;
    float totalTimer = 0;
    public GameObject penguinFriends;
    int direct = -1;
    public float speed = 10f;


    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        spawnPointLeft = spawnPoint[1].GetComponentsInChildren<Transform>();
        spawnPointRight = spawnPoint[5].GetComponentsInChildren<Transform>();

    }
    private void OnEnable()
    {
        totalTimer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        totalTimer += Time.deltaTime;

        if (timer > 0.8f && totalTimer < 3)
        {
            direct = -1;
            GameObject friendPenguin;
            int index = Random.Range(1, 3);
            if (index == 1)
                friendPenguin = Instantiate(penguinFriends, spawnPointLeft[Random.Range(1, spawnPointLeft.Length)].position, Quaternion.identity);
            else
                friendPenguin = Instantiate(penguinFriends, spawnPointRight[Random.Range(1, spawnPointRight.Length)].position, Quaternion.identity);

            friendPenguin.GetComponent<SpriteRenderer>().flipX = gameObject.transform.position.x > friendPenguin.GetComponent<Rigidbody2D>().position.x;
            if (friendPenguin.GetComponent<SpriteRenderer>().flipX)
                direct = 1;
            // Debug.Log(direct);
            friendPenguin.GetComponent<Rigidbody2D>().velocity = new Vector2(direct * speed, 0);

            //소환
            timer = 0;

        }
        if (totalTimer > 6)
            totalTimer = 0;
    }
    public void PlaySkill()
    {
        totalTimer = 0;
    }
}
