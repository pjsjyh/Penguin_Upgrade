using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        // GameManager.Instance�� null�� �ƴ��� Ȯ���ϴ� ����� �޽���
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance�� null�Դϴ�!");
        }
    }
    private void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    GameObject obj = GameManager.Instance.poolmanager.Get(1);
        //    obj.transform.position = new Vector3(0, 0, 0);
        //}
    }
}
