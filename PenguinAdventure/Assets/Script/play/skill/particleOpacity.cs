using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleOpacity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // SpriteRenderer의 color를 가져오기
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // 현재 color를 변수로 가져와 알파 값을 수정
        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp(color.a - 0.5f * Time.deltaTime, 0, 1); // 알파 값 증가 (0~1 사이로 제한)

        // 수정된 color를 다시 SpriteRenderer의 color에 할당
        spriteRenderer.color = color;
    }
}
