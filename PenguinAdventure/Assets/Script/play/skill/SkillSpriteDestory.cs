using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpriteDestory : MonoBehaviour
{
    float timer;
    public float playTime = 5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > playTime)
        {
            Destroy(gameObject);
        }
    }
}
