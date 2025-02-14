using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PlayerInfoManager;
using LoginM;
public class TextLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMeshPro; // TextMeshPro 텍스트 컴포넌트
    public int maxCharacters = 13; // 최대 글자 수
    public TMP_InputField inputfield;
    public TextMeshProUGUI warningMessage;

    public Button button;
    public Sprite image1;                  // 텍스트가 없을 때 이미지
    public Sprite image2;
    private Image buttonImage;
    int wordlen = 0;
    string word = "";
    private void Start()
    {

        buttonImage = button.GetComponent<Image>();

        warningMessage.gameObject.SetActive(false);

        inputfield.characterLimit = maxCharacters;
        inputfield.onValueChanged.AddListener(OnTextChanged);
    }
    private void OnTextChanged(string text)
    {
        wordlen = text.Length;
        word = text;
        if (text.Length == 0)
        {
            buttonImage.raycastTarget = false;
            buttonImage.sprite = image1;
        }
        else
        {
            buttonImage.raycastTarget = true;
            buttonImage.sprite = image2;

        }
        // 글자 수가 최대 글자 수를 초과할 때 경고 메시지 표시
        if (text.Length >= maxCharacters)
        {
            // 텍스트를 잘라내어 최대 글자 수로 제한
            inputfield.text = text.Substring(0, maxCharacters);
            // 경고 메시지 활성화
            warningMessage.text = $"{maxCharacters} 글자 이내로 입력해 주세요!";
            warningMessage.gameObject.SetActive(true);
        }
        else
        {
            // 경고 메시지 비활성화
            warningMessage.gameObject.SetActive(false);
        }
    }
    public void buttonClick()
    {
        if (wordlen != 0)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LobbyScene");

            PlayerManager.Instance.InitializePlayer();
            PlayerManager.Instance.myPlayer._name = word;

        }
    }
}
