using System.Runtime.InteropServices;
using UnityEngine;

public class WebGLFirebaseManager : MonoBehaviour
{
    public static WebGLFirebaseManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [DllImport("__Internal")]
    private static extern void SaveScoreToFirebase(string username, float score);

    public void SaveScore(string username, float score)
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Debug.Log("🔥 WebGL에서 Firebase 점수 저장 요청");

            // 🔹 JavaScript 호출 오류 확인 (예외 처리 추가)
            try
            {
                SaveScoreToFirebase(username, score);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"❌ WebGL에서 JavaScript 호출 중 오류 발생: {e.Message}");
            }
        }
        else
        {
            Debug.Log($"🖥 Firebase 점수 저장 (에디터에서 실행): {username} - {score}");
        }
    }
}
