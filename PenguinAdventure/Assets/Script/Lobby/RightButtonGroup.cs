using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RightButtonGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform panel1; // 첫 번째 화면
    public RectTransform panel2; // 두 번째 화면
    public RectTransform panel3; // 세 번째 화면
    public float slideDuration = 0.5f; // 슬라이드 시간

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

    // 1번 화면으로 다시 슬라이드하는 함수
    public void SlideToPanel21()
    {
        panel1.DOAnchorPos(new Vector2(0, 0), slideDuration).SetEase(Ease.OutExpo);
        panel2.DOAnchorPos(new Vector2(Screen.width*2, 0), slideDuration).SetEase(Ease.OutExpo);
    }
}
