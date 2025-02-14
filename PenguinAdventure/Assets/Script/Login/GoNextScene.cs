using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nameInput;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0은 마우스 왼쪽 버튼
        {
            ActivateInputField();
        }
    }
    private void ActivateInputField()
    {
        // 입력 창 패널 활성화 및 입력 필드 포커스 설정
        nameInput.SetActive(true);
        //inputField.ActivateInputField(); // 입력 필드에 포커스 설정
    }
    public void InputClose()
    {
        nameInput.SetActive(false);
    }
   
}
