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
        if (Input.GetMouseButtonDown(0)) // 0�� ���콺 ���� ��ư
        {
            ActivateInputField();
        }
    }
    private void ActivateInputField()
    {
        // �Է� â �г� Ȱ��ȭ �� �Է� �ʵ� ��Ŀ�� ����
        nameInput.SetActive(true);
        //inputField.ActivateInputField(); // �Է� �ʵ忡 ��Ŀ�� ����
    }
    public void InputClose()
    {
        nameInput.SetActive(false);
    }
   
}
