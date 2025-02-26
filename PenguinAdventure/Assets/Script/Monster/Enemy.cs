using UnityEngine;

// 캐릭터와 공통된 행동을 가지는 부모 클래스
public abstract class Enemy : MonoBehaviour
{
    public float moveSpeed = 3.0f; // 이동 속도
    public float blood = 100f; //몬스터 피
    public float Damage = 5f; //데미지
    public float ExperienceCapacity = 10; //떨어지는 경험치량

    //가진 경험치에 따라 떨어지는 아이콘 수 다르게 조절하는 함수


    // 충돌 처리, 몬스터와 보스가 각각 다르게 구현할 수 있음
    public abstract void OnCollisionEnter(Collision collision);
}

// Monster 클래스
public class miscellaneous : Enemy
{
    // 캐릭터와 충돌하면 어떤 동작을 할지 정의
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 충돌 처리 (예: 캐릭터에게 피해를 입히거나 반응하기)
            Debug.Log("Monster collided with the player!");
        }
    }
}

// Boss 클래스
public class Boss : Enemy
{
    public float skillCooldown = 5.0f; // 스킬 사용 쿨타임
    private float lastSkillTime;

    // 캐릭터와 충돌 시 보스의 반응 정의
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 충돌 시 보스의 반응
            Debug.Log("Boss collided with the player!");
        }
    }

    // 스킬 사용 메서드
    public void UseSkill()
    {
        Debug.Log("Boss used a skill!");
        // 스킬 효과 추가
    }

    private void Update()
    {


        // 스킬 쿨타임이 지나면 스킬 사용
        if (Time.time - lastSkillTime >= skillCooldown)
        {
            Debug.Log("/?");
            UseSkill();
            lastSkillTime = Time.time;
        }
    }
}
