using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerInfoManager;
using TMPro;
using System.Runtime.InteropServices;
public class LobbyManager : MonoBehaviour
{   public static LobbyManager Instance { get; private set; }
    [SerializeField] private PassiveManager passiveBtn;
    [SerializeField] CanvasGroup panel;

    // Start is called before the first frame update
    [DllImport("__Internal")]
    private static extern void LoadRankingsFromFirebase();

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            LoadRankingsFromFirebase();
        }
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(this.gameObject);


            }
        }
        //panel.SetActive(true);
        //panel.alpha = 1f;

    }



}
