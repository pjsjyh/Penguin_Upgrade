using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RankingBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RankingPanel;

    private void Start()
    {
        RankingPanel = GameObject.Find("RankingPanel").transform.GetChild(0).gameObject;
    }
    public void RankingOn()
    {
       
        RankingPanel.SetActive(true);
    }
    public void RankingOff()
    {
        RankingPanel.SetActive(false);
    }
}
