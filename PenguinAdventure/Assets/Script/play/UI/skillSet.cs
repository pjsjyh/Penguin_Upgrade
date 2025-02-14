using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class skillSet : MonoBehaviour
{
    GameObject gameManageObject;

    // Start is called before the first frame update
    void Start()
    {
        gameManageObject = GameObject.Find("GameManage");
    }

    private void OnEnable()
    {

        if (!gameManageObject)
        {
            gameManageObject = GameObject.Find("GameManage");
        }
        // Debug.Log(gameManageObject);
        if (gameManageObject != null)
        {
            skillManage skillScript = gameManageObject.GetComponent<skillManage>();
            skillScript.setSkill();
        }
    }

    public void selectedListSkill(GameObject clickedSkillBtn)
    {
        if (!gameManageObject)
        {
            gameManageObject = GameObject.Find("GameManage");
        }
        // Debug.Log(gameManageObject);
        if (gameManageObject != null)
        {
            skillManage skillScript = gameManageObject.GetComponent<skillManage>();
            // Debug.Log(clickedSkillBtn.GetComponent<skillInfo>().SkillName);
            skillScript.SelectSkill(clickedSkillBtn.GetComponent<skillInfo>().SkillName);
        }
    }
}
