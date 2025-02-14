using UnityEngine;
using UnityEngine.SceneManagement;
using LoginM;
public class gameoverManager : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        // 씬 이름으로 로드
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        if (sceneName == "LobbyScene")
        {
            LoginManager.Instance.startsong.Play();
        }
    }
}
