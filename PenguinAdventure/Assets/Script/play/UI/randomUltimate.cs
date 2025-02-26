using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerInfoManager;
public class randomUltimate : MonoBehaviour
{
    public Texture[] Ultimate; // 사용할 텍스처 배열
    public int selectUltimate; // 선택할 텍스처 인덱스
    private void OnEnable()
    {
        Time.timeScale = 0f;       // 게임 일시 정지

        int length = PlayerManager.Instance.passiveList.Count;
        int randomNumber = Random.Range(0, length - 1);
        selectUltimate = randomNumber;
        GameObject ultimateObject = GameObject.Find("getultimateIcon");
        // ultimateObject에서 RawImage 컴포넌트를 가져오기
        RawImage rawImage = ultimateObject.GetComponent<RawImage>();

        if (rawImage != null && Ultimate.Length > selectUltimate)
        {
            // 텍스처 할당
            // rawImage.texture = Ultimate[selectUltimate];
            string imagePath = PlayerManager.Instance.passiveList[randomNumber].imgSource;
            Texture2D texture = Resources.Load<Texture2D>(imagePath);
            rawImage.texture = texture;
            PlayerManager.Instance.passiveList[randomNumber].nowLevel += 1;
            //GameObject a = GameObject.Find(PlayerManager.Instance.passiveList[randomNumber].title);
            // a.GetComponent<Passive>().ImageSet(true);
            //a.GetComponent<Passive>().BtnIsActive(true);
        }
        else
        {
            Debug.LogWarning("RawImage 컴포넌트가 없거나 인덱스 범위를 벗어났습니다.");
        }
    }
}
