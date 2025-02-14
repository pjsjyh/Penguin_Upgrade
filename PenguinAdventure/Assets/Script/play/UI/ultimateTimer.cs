using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ultimateTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // 숫자를 표시할 TMP Text
    public int startValue = 10; // 초기화할 숫자

    private Coroutine countdownCoroutine;
    private GameObject ultimateBtn;

    private void OnEnable()
    {
        // Image가 활성화될 때 숫자 초기화 및 카운트다운 시작
        ultimateBtn = GameObject.Find("GameManage");
        InitializeCountdown();
    }

    private void OnDisable()
    {
        // Image가 비활성화될 때 코루틴 정지
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }
    private void InitializeCountdown()
    {
        // 초기 숫자 설정
        countdownText.text = startValue.ToString();

        // 기존 코루틴이 있다면 정지 후 새로 시작
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        int currentCount = startValue;

        while (currentCount > 0)
        {
            countdownText.text = currentCount.ToString();
            yield return new WaitForSeconds(1f);
            currentCount--;
        }

        Debug.Log("?");
        ultimateBtn.GetComponent<useUltimate>().nowUseWltimate = false;
        countdownText.text = "0"; // 마지막으로 0으로 설정
        gameObject.SetActive(false);
    }
}
