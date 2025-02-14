using System;
using System.Collections.Generic;

public class RandomSample
{
    public static List<T> GetRandomElements<T>(List<T> list, int count)
    {
        List<T> result = new List<T>();         // 결과를 저장할 리스트
        List<int> usedIndices = new List<int>(); // 중복 방지를 위한 인덱스 리스트
        Random random = new Random();            // 랜덤 생성기

        while (result.Count < count)
        {
            int index = random.Next(list.Count); // 리스트에서 랜덤 인덱스 생성

            if (!usedIndices.Contains(index))    // 중복 확인
            {
                result.Add(list[index]);         // 중복이 없으면 결과에 추가
                usedIndices.Add(index);          // 사용된 인덱스로 등록
            }
        }
        return result;
    }
}
