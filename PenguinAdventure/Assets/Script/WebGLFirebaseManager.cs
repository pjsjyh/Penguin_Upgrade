using Firebase.Database;
using System.Collections.Generic;
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

#if UNITY_WEBGL && !UNITY_EDITOR
[DllImport("__Internal")]
private static extern void SaveScoreToFirebase(string username, int score);
#endif
    public void SaveScore(string username, int score)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
    Debug.Log("WebGL에서 Firebase 점수 저장 요청");

    try
    {
        SaveScoreToFirebase(username, score);
    }
    catch (System.Exception e)
    {
        Debug.LogError($"❌ WebGL에서 JavaScript 호출 중 오류 발생: {e.Message}");
    }

#else
        // Android / iOS / Editor
        string userId = SystemInfo.deviceUniqueIdentifier;

        var data = new Dictionary<string, object>
    {
        { "username", username },
        { "score", score }
    };

        FirebaseDatabase.DefaultInstance.RootReference
            .Child("rankings")
            .Child(userId)
            .SetValueAsync(data)
            .ContinueWith(task =>
            {
                if (task.IsCompleted)
                    Debug.Log("✅ Firebase 점수 저장 성공 (모바일)");
                else
                    Debug.LogError("❌ Firebase 점수 저장 실패 (모바일)");
            });
#endif
    }
}
