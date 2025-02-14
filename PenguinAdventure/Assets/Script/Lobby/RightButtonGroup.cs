using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RightButtonGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform panel1; // ù ��° ȭ��
    public RectTransform panel2; // �� ��° ȭ��
    public RectTransform panel3; // �� ��° ȭ��
    public float slideDuration = 0.5f; // �����̵� �ð�

    public void SlideToPanel12()
    {
        panel1.DOAnchorPos(new Vector2(-Screen.width*2, 0), slideDuration).SetEase(Ease.OutExpo);
        panel2.DOAnchorPos(new Vector2(0, 0), slideDuration).SetEase(Ease.OutExpo);
    }
    public void SlideToPanel13()
    {
        panel1.DOAnchorPos(new Vector2(Screen.width*2, 0), slideDuration).SetEase(Ease.OutExpo);
        panel3.DOAnchorPos(new Vector2(0, 0), slideDuration).SetEase(Ease.OutExpo);
    }
    public void SlideToPane31()
    {
        panel1.DOAnchorPos(new Vector2(0, 0), slideDuration).SetEase(Ease.OutExpo);
        panel3.DOAnchorPos(new Vector2(-Screen.width*2, 0), slideDuration).SetEase(Ease.OutExpo);
    }

    // 1�� ȭ������ �ٽ� �����̵��ϴ� �Լ�
    public void SlideToPanel21()
    {
        panel1.DOAnchorPos(new Vector2(0, 0), slideDuration).SetEase(Ease.OutExpo);
        panel2.DOAnchorPos(new Vector2(Screen.width*2, 0), slideDuration).SetEase(Ease.OutExpo);
    }
}
