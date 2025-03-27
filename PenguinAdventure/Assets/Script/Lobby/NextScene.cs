using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoginM;
public class NextScene : MonoBehaviour
{
    public CanvasGroup pane;

   public void gonext()
    {
        //pane.SetActive(false);
        //pane.alpha = 0f;
        StartCoroutine(LoadPlayScene());
        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("playScene");

        LoginManager.Instance.startsong.Stop();
        //GameManager.Instance.IsGameStart = true;
    }
    IEnumerator LoadPlayScene()
    {
        // ✅ 먼저 로딩 씬을 불러옴
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync("LoadingScene");
        yield return new WaitUntil(() => loadingScene.isDone); // 로딩 씬이 완전히 로드될 때까지 기다림
        GameObject.Find("PenguinPlayer").transform.position = new Vector3(0, 0, 0);

        // ✅ 오브젝트 풀 초기화 (MonsterPoolManager의 몬스터 생성이 끝날 때까지 대기)
        yield return StartCoroutine(check());

        // ✅ 모든 것이 끝난 후 PlayScene 불러오기
        AsyncOperation playScene = SceneManager.LoadSceneAsync("PlayScene");

        // ✅ 씬 로딩이 끝날 때까지 대기
        yield return new WaitUntil(() => playScene.isDone);
        // ✅ 게임 시작
        GameManager.Instance.IsGameStart = true;
    }
    IEnumerator check()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (MonsterPoolManager.Instance.ismakeFinish)
            {
                break;
            }
        }

    }
}
