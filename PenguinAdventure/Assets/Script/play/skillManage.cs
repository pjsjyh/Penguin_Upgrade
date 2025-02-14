using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System; // LINQ 기능 사용을 위한 네임스페이스

[System.Serializable] // Unity Inspector에서 표시되도록 직렬화
public class inputSkill
{
    //스킬 데미지
    //근거리, 광역, 원거리
    //쓰게될 파티클


    private int skillLevel = 0;
    public float ReuseTime = 1f;     //재사용 시간
    public GameObject SkillImg;
    public int passiveCount = 0;

    public Sprite skillIcon;
    public string skillName;
    public string skillExplane;

    //func
    public int SkillLevel
    {
        get { return skillLevel; }
        set { skillLevel = value; }
    }
}


[System.Serializable] // Unity Inspector에서 표시되도록 직렬화
public class skillView
{
    public Button skillBtn;
    public RawImage skillIcon;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillExplane;

}


[System.Serializable] // Unity Inspector에서 표시되도록 직렬화
public class presentSkill
{
    public List<inputSkill> list = new List<inputSkill> { null, null, null, null, null };
}

public class skillManage : MonoBehaviour
{
    public GameObject skillList;
    public List<skillView> skillViews;
    public List<inputSkill> skillItems;
    public Sprite sprite;
    List<string> selectMySkill = new List<string>();
    List<inputSkill> skillList_select = new List<inputSkill>();
    bool Once = false;

    public GameObject Friendsview;
    public GameObject sardineview;
    public GameObject IceStampView;
    public GameObject IceZoneView;
    public GameObject LightSkillView;

    private void Awake()
    {
        skillList_select = skillItems;
        SelectSkill(skillItems[3].skillName);
        GameObject.Find("PenguinPlayer").GetComponent<waterDropFunc>().numberOfBullets = 1;
    }
    public void setSkill()
    {
        // Debug.Log(Once);

        List<inputSkill> randomNumbers = RandomSample.GetRandomElements(skillList_select, Math.Min(3, skillList_select.Count));
        int i = 0;
        foreach (inputSkill number in randomNumbers)
        {

            skillViews[i].skillIcon.texture = number.skillIcon.texture;
            skillViews[i].skillName.text = number.skillName + "  " + (number.SkillLevel + 1) + " / 5";
            skillViews[i].skillExplane.text = number.skillExplane;
            skillViews[i].skillBtn.GetComponent<skillInfo>().SkillName = number.skillName;
            i++;

        }
        if (i <= 2)
        {
            //자식객체 다 setActive하고 

            int childCount = skillViews[i].skillBtn.transform.childCount;

            for (int j = 0; j < childCount; j++)
            {
                GameObject Btnchild = skillViews[i].skillBtn.transform.GetChild(j).gameObject;
                Btnchild.gameObject.SetActive(false);
                skillViews[i].skillBtn.interactable = false;
                skillViews[i].skillBtn.GetComponent<Image>().sprite = sprite;
            }

            i++;
            if (i > 2)
                return;
        }
    }

    public void SelectSkill(string name)
    {
        inputSkill foundSkill = skillItems.Find(skill => skill.skillName == name);
        // foundSkill.SkillLevel = foundSkill.SkillLevel + 1;
        // mySkillList(foundSkill);
        if (foundSkill != null)
        {
            // Debug.Log($"찾은 스킬: {foundSkill.skillName}");
            foundSkill.SkillLevel = foundSkill.SkillLevel + 1;
            mySkillList(foundSkill);
        }
        else
        {
            Debug.Log($"스킬 '{name}'을(를) 찾을 수 없습니다.");
        }
    }

    public void mySkillList(inputSkill skill)
    {
        List<GameObject> childObjects = new List<GameObject>();

        int childCount = skillList.transform.childCount; // 자식의 개수 가져오기

        for (int i = 0; i < childCount; i++)
        {
            GameObject child = skillList.transform.GetChild(i).gameObject;
            childObjects.Add(child);
        }

        // 결과 출력
        foreach (var child in childObjects)
        {
            skillInfo info = child.GetComponent<skillInfo>();
            if (info.SkillName == skill.skillName)
            {
                info.level = skill.SkillLevel;
                child.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + skill.SkillLevel + " / 5";

                if (skill.skillName == "물방울 쏘아내기!" || skill.skillName == "원거리 공격 개수 증가")
                {
                    Debug.Log(skill.skillName);
                    GameObject.Find("PenguinPlayer").GetComponent<waterDropFunc>().numberOfBullets += 1;
                }
                if (skill.skillName == "친구야 도와줘!")
                {
                    GameObject.Find("FriendsSkillSpawner").GetComponent<firensSkill>().speed += 1;
                }

                if (skill.skillName == "'ICE ZONE' 이라는 것이다")
                {
                    // IceZoneView.SetActive(true);
                    IceZoneView.transform.localScale *= 1.2f;
                    // IceStampView.GetComponent<firensSkill>().speed += 1;
                }
                if (skill.SkillLevel == 5)
                {
                    //삭제하는거 다시 만들기
                    inputSkill skillToRemove = skillList_select.Find(ski => ski.skillName == skill.skillName);

                    if (skillToRemove != null)
                    {
                        // 해당 스킬 삭제
                        skillList_select.Remove(skillToRemove);
                        Debug.Log($"스킬 '{name}'이(가) 삭제되었습니다." + skillList_select.Count);
                    }
                    else
                    {
                        Debug.Log($"스킬 '{name}'을(를) 찾을 수 없어 삭제하지 못했습니다.");
                    }
                }

                break;
            }
            else if (info.SkillName == "")
            {
                if (skill.skillName == "물방울 쏘아내기!" || skill.skillName == "원거리 공격 개수 증가")
                {
                    Debug.Log(skill.skillName);
                    GameObject.Find("PenguinPlayer").GetComponent<waterDropFunc>().numberOfBullets += 1;
                }

                if (skill.skillName == "친구야 도와줘!")
                {
                    Friendsview.SetActive(true);
                    Friendsview.GetComponent<firensSkill>().speed += 1;
                }

                if (skill.skillName == "정어리 공격!")
                {
                    sardineview.SetActive(true);
                    // sardineview.GetComponent<firensSkill>().speed += 1;
                }
                if (skill.skillName == "얼음도장 쾅!")
                {
                    IceStampView.SetActive(true);
                    // IceStampView.GetComponent<firensSkill>().speed += 1;
                }
                if (skill.skillName == "'ICE ZONE' 이라는 것이다")
                {
                    IceZoneView.SetActive(true);
                    // IceZoneView.transform.localScale *= 1.2f;
                    // IceStampView.GetComponent<firensSkill>().speed += 1;
                }
                if (skill.skillName == "태양광 에너지")
                {
                    LightSkillView.SetActive(true);
                    // IceZoneView.transform.localScale *= 1.2f;
                    // IceStampView.GetComponent<firensSkill>().speed += 1;
                }

                selectMySkill.Add(skill.skillName);
                info.SkillName = skill.skillName;
                info.level = skill.SkillLevel;
                child.GetComponent<RawImage>().texture = skill.skillIcon.texture;
                child.transform.GetChild(0).gameObject.SetActive(true);
                if (selectMySkill.Count == 5 && !Once)
                {
                    Once = true;
                    List<inputSkill> foundSkills = skillList_select
            .Where(skill => selectMySkill.Contains(skill.skillName))
            .ToList();

                    // 결과 확인
                    if (foundSkills.Count > 0)
                    {
                        // Debug.Log(foundSkills.Count);
                        skillList_select.Clear(); // 기존 리스트의 내용을 지움
                        skillList_select.AddRange(foundSkills); // foundSkills의 내용을 skillList_select에 추가

                    }
                    else
                    {
                        Debug.Log("조건에 맞는 스킬을 찾을 수 없습니다.");
                    }
                    // inputSkill foundSkill = skillItems.Find(skill => selectMySkill.Contains(skill.skillName));
                }

                break;
            }
            else
            {

            }

        }
    }


    //스킬 코루틴
    //물방울 //passiveCount
    public IEnumerator WaterDrop()
    {
        //ReuseTime
        float ReuseTime = 1f;
        float bulletSpeed = 10f; // 속도
        GameObject player = GameObject.Find("PenguinPlayer");

        inputSkill foundSkill = skillItems.Find(skill => skill.skillName == "물방울 쏘아내기!");

        if (foundSkill != null)
        {
            while (true)
            {

                if (player != null)
                {
                    // if (player.transform.localScale)
                    Debug.Log(0);
                }

                yield return new WaitForSeconds(ReuseTime);
            }
        }




    }

}
