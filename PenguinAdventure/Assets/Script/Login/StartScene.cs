using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField] private string startSceneAddress = "Assets/Scenes/LoginScene.unity";
    // Start is called before the first frame update
    void Awake()
    {
        Addressables.LoadSceneAsync(startSceneAddress, LoadSceneMode.Single);
    }

}
