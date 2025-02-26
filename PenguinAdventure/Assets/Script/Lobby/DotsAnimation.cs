using System.Collections;
using TMPro;
using UnityEngine;

public class DotsAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // TextMeshPro ������Ʈ
    public float interval = 0.5f; // ���� ���ϴ� ����

    private string baseText = "Loading"; // �⺻ �ؽ�Ʈ
    private string[] dotPatterns = { ". . .", "  . .", "   .", "    " }; // ���� ������� ����
    private int index = 0;

    void Start()
    {
        StartCoroutine(AnimateDots());
    }

    IEnumerator AnimateDots()
    {
        while (true)
        {
            textMesh.text = baseText + " " + dotPatterns[index]; // "Loading " + ���� ����
            index = (index + 1) % dotPatterns.Length; // ���� ��ȯ
            yield return new WaitForSeconds(interval);
        }
    }
}
