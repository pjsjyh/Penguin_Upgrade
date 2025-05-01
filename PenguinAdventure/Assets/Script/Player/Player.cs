using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfoManager;
public class Player : MonoBehaviour
{
    public float minX = -28f;  // x 최소값
    public float maxX = 28f;   // x 최대값
    public float minY = -17f;  // y 최소값
    public float maxY = 17f;   // y 최대값
    public Vector2 inputVec;
    Rigidbody2D rigid;
    public float speed;
    SpriteRenderer spriter;
    public VariableJoystick variableJoystick;
    bool joyon = false;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        speed = PlayerManager.Instance.myPlayer._moveSpeed / 100;
        if (speed == 0) speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        if (variableJoystick == null)
        {
            try
            {
                variableJoystick = GameObject.Find("Dynamic").transform.GetChild(0).GetComponent<VariableJoystick>();
                joyon = true;
                GameObject.Find("Dynamic").SetActive(true);
            }
            catch (System.Exception e)
            {

            }
        }
        if (Application.isMobilePlatform)
        {
            if (variableJoystick == null)
            {
                try
                {
                    variableJoystick = GameObject.Find("Dynamic").transform.GetChild(0).GetComponent<VariableJoystick>();
                    joyon = true;
                }
                catch (System.Exception e)
                {

                }
            }
        }
    }
    private void FixedUpdate()
    {
        //if (joyon)
        //{
        //    Vector2 inputVec = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        //    Vector2 nextVec = inputVec.normalized * speed; // 이동할 벡터 계산
        //    Vector2 targetPosition = rigid.position + nextVec; // 이동 후 예상 위치

        //    // 예상 위치의 x, y 값을 설정된 범위 내로 제한
        //    targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        //    targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        //    // 제한된 위치로 이동
        //    rigid.MovePosition(targetPosition);
        //}
        Vector2 inputVec;

        if (Application.isMobilePlatform)
        {
            inputVec = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        }
        else
        {
            inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        //이동 벡터 계산
        Vector2 nextVec = inputVec.normalized * speed;
        Vector2 targetPosition = rigid.position + nextVec;

        //범위 제한
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        //위치 이동
        rigid.MovePosition(targetPosition);


    }
    private void LateUpdate()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Vector2 inputVec = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
            if (inputVec.x != 0)
            {
                spriter.flipX = inputVec.x > 0;
            }

        }
        else
        {
            if (inputVec.x != 0)
            {
                spriter.flipX = inputVec.x > 0;
            }
        }
    }
}
