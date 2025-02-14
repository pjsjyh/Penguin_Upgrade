using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingSardine : MonoBehaviour
{

    // 휘두를 시간과 최종 각도 설정
    public float duration = 0.1f; // 휘두르는 시간
    public float startAngle = 130f; // 시작 각도
    public float endAngle = -90f; // 끝 각도

    void OnEnable()
    {
        StartCoroutine(Swing());

    }

    private IEnumerator Swing()
    {
        float elapsedTime = 0f; // 경과 시간 초기화
        // 현재 각도 가져오기
        float initialAngle = transform.rotation.eulerAngles.z;

        while (elapsedTime < duration)
        {
            // 경과 시간을 기반으로 보간
            float t = elapsedTime / duration;
            // 스프라이트의 rotation.z 보간
            float zRotation = Mathf.Lerp(startAngle, endAngle, t);
            transform.rotation = Quaternion.Euler(0, 0, zRotation);

            elapsedTime += Time.deltaTime; // 경과 시간 업데이트
            yield return null; // 다음 프레임까지 대기
        }

        // 최종 각도로 정확하게 설정
        transform.rotation = Quaternion.Euler(0, 0, endAngle);
        Destroy(gameObject);
    }
}
