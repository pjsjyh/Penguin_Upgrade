using System.Collections;
using TMPro;
using UnityEngine;

public class DotsAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // TextMeshPro 오브젝트
    public float interval = 0.5f; // 점이 변하는 간격

    private string baseText = "Loading"; // 기본 텍스트
    private string[] dotPatterns = { ". . .", "  . .", "   .", "    " }; // 점이 사라지는 패턴
    private int index = 0;

    void Start()
    {
        StartCoroutine(AnimateDots());
    }

    IEnumerator AnimateDots()
    {
        while (true)
        {
            textMesh.text = baseText + " " + dotPatterns[index]; // "Loading " + 패턴 적용
            index = (index + 1) % dotPatterns.Length; // 패턴 순환
            yield return new WaitForSeconds(interval);
        }
    }
}
