using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayerInfoManager;

public class PassiveUISetting : MonoBehaviour
{
    [SerializeField] private GameObject health;
    [SerializeField] private GameObject defense;
    [SerializeField] private GameObject damage;
    [SerializeField] private GameObject speed;

    private RectTransform healthBar;
    private TextMeshProUGUI healthNum;
    private RectTransform defenseBar;
    private TextMeshProUGUI defenseNum;
    private RectTransform damageBar;
    private TextMeshProUGUI damageNum;
    private RectTransform speedBar;
    private TextMeshProUGUI speedNum;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = health.transform.Find("HealthBarBack/HealthBar").GetComponent<RectTransform>();
        healthNum = health.transform.Find("HealthNum").GetComponent<TextMeshProUGUI>();
        defenseBar = defense.transform.Find("DefenseBarBack/DefenseBar").GetComponent<RectTransform>();
        defenseNum = defense.transform.Find("DefenseNum").GetComponent<TextMeshProUGUI>();
        damageBar = damage.transform.Find("DamageBarBack/DamageBar").GetComponent<RectTransform>();
        damageNum = damage.transform.Find("DamageNum").GetComponent<TextMeshProUGUI>();
        speedBar = speed.transform.Find("SpeedBarBack/SpeedBar").GetComponent<RectTransform>();
        speedNum = speed.transform.Find("SpeedNum").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        healthNum.text = PlayerManager.Instance.myPlayer._hp.ToString();
        defenseNum.text = PlayerManager.Instance.myPlayer._defense.ToString();
        damageNum.text = PlayerManager.Instance.myPlayer._damage.ToString();
        speedNum.text = PlayerManager.Instance.myPlayer._moveSpeed.ToString();
        if (PlayerManager.Instance != null)
        {
            if ((float)PlayerManager.Instance.myPlayer._hp / 100 >= 0)
                healthBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._hp / 100, 1, 1);
            if ((float)PlayerManager.Instance.myPlayer._defense / 100 >= 0)
                defenseBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._defense / 100, 1, 1);
            if ((float)PlayerManager.Instance.myPlayer._damage / 100 >= 0)
                damageBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._damage / 100, 1, 1);
            if ((float)PlayerManager.Instance.myPlayer._moveSpeed / 100 >= 0)
                speedBar.localScale = new Vector3((float)PlayerManager.Instance.myPlayer._moveSpeed / 100, 1, 1);
        }


    }
}
