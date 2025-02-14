using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDropFunc : MonoBehaviour
{
    public GameObject bulletPrefab;         // 총알 프리팹
    public Transform bulletSpawnPoint;      // 총알이 발사되는 위치
    public float bulletSpeed = 10f;         // 총알 속도
    public int numberOfBullets = 8;         // 발사할 총알 수 (원 형태로 퍼지는)
    public float fireRate = 1f;             // 공격 간격 (초 단위)

    public bool friendsCk = false;
    private bool isFiring = false;          // 발사 상태 플래그
    private Coroutine fireCoroutine;
    void Start()
    {
        // 발사 중이 아니면 코루틴 시작
        fireCoroutine = StartCoroutine(FireSpreadAttack());
        // isFiring = true;
    }


    IEnumerator FireSpreadAttack()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(fireRate); // 공격 간격을 기다림
        }
    }
    void Fire()
    {
        // 원형으로 발사할 각도 계산
        float angleStep = 360f / numberOfBullets;

        float angle = gameObject.GetComponent<SpriteRenderer>().flipX ? 0f : 180f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            // 각도에 따라 방향 벡터 설정
            float bulletDirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            // 총알 생성
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            // 총알의 속도 설정
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            // 총알의 회전 설정
            float bulletAngle = angle - 180f; // Z축 회전 각도 계산 (Sprite는 기본적으로 Y축을 기준으로 방향을 맞추기 때문에 보정을 위해 -90도)
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, bulletAngle); // 회전값 적용

            // 각도를 다음 방향으로 변경
            angle += angleStep;
        }
    }

}
