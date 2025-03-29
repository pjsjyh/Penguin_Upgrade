using UnityEngine;
using UnityEngine.SceneManagement;
using LoginM;
using UnityEngine.AddressableAssets;

public class gameoverManager : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        // 씬 이름으로 로드
        Time.timeScale = 1f;
       // SceneManager.LoadScene(sceneName);
        if (sceneName == "LobbyScene")
        {
            Addressables.LoadSceneAsync("Assets/Scenes/LobbyScene.unity", LoadSceneMode.Single);
            LoginManager.Instance.startsong.Play();
        }
    }
}
