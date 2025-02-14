using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer = 0;
    float totalTimer = 0;

    public GameObject sunParticle;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    private void OnEnable()
    {
        totalTimer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        totalTimer += Time.deltaTime;

        if (timer > 0.5f && totalTimer < 3)
        {
            //소환
            timer = 0;
            Instantiate(sunParticle, spawnPoint[Random.Range(1, spawnPoint.Length)].position, Quaternion.identity);


        }
        if (totalTimer > 7)
            totalTimer = 0;


    }
}
