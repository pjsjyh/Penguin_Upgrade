using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartEventSet : MonoBehaviour
{
    // Start is called before the first frame update
    Button startButton;
    private NextScene nextScene;
    void Start()
    {
        nextScene = GameObject.Find("GameManager").GetComponent<NextScene>();

        startButton = this.GetComponent<Button>();
        if (startButton != null)
        {
            startButton.onClick.AddListener(nextScene.gonext);
            Debug.Log("✅ 버튼 클릭 시 GoNext 실행!");
        }
        else
        {
            Debug.LogError("❌ Start 버튼이 연결되지 않았습니다!");
        }
    }

   
}
