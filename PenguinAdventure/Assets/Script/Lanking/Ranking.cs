using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Extensions;

public struct RankInfo
{
    public string name;
    public int score;

    public RankInfo(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
public class Ranking : MonoBehaviour
{
   
    public GameObject rankingPre;
    public RankInfo[] ranks = new RankInfo[100];
    private int rankCount = 0; // 현재 저장된 랭킹의 개수

    public TextMeshProUGUI nameText;  // Unity UI에 표시할 Text 객체
    public TextMeshProUGUI scoreText;  // Unity UI에 표시할 Text 객체
    public ScrollRect scrollRect;
    public RectTransform contentRectTransform;
    // Firebase에서 데이터를 받아서 UI에 표시
    public void canvasReset()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRectTransform);
        //scrollRect.normalizedPosition = new Vector2(0, 1);
    }
    public void OnRankingsLoaded(string jsonData)
    {
        Debug.Log("랭킹 데이터 로드 완료: " + jsonData);
        canvasReset();
          // JSON 데이터를 C# 리스트로 변환
          RankingData[] rankings = JsonHelper.FromJson<RankingData>(jsonData);
        nameText.text = "";
        scoreText.text = "";
        // UI 업데이트
        //rankingText.text = "랭킹 n";
        for (int i = 0; i < rankings.Length; i++)
        {
            nameText.text += $"{i + 1}. {rankings[i].username}\n";
            scoreText.text += $"{rankings[i].score}점\n";
        }
    }
    [System.Serializable]
    public class RankingData
    {
        public string username;
        public int score;
    }

    // JSON 배열 변환을 위한 Helper 클래스
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            string wrappedJson = "{ \"items\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrappedJson);
            return wrapper.items;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] items;
        }
    }
    public void LoadTop10Rankings()
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("rankings")
            .OrderByChild("score")
            .LimitToLast(10)
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    List<RankingData> rankings = new();

                    foreach (var child in task.Result.Children)
                    {
                        string username = child.Child("username").Value.ToString();
                        int score = int.Parse(child.Child("score").Value.ToString());

                        rankings.Add(new RankingData { username = username, score = score });
                    }

                rankings.Sort((a, b) => b.score.CompareTo(a.score));
                    
                    makeUI(rankings);
                }
                else
                {
                    Debug.LogError("Firebase 랭킹 불러오기 실패: " + task.Exception);
                }
            });
    }
    public void makeUI(List<RankingData> rankings)
    {
        nameText.text = "";
        scoreText.text = "";
        int i = 0;
        // 출력
        foreach (var entry in rankings)
        {
            nameText.text += $"{i + 1}. {entry.username}\n";
            scoreText.text += $"{entry.score}점\n";
            i++;
        }
    }
}


