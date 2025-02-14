using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sardineSkill : MonoBehaviour
{
    public GameObject bulletPrefab;         // 총알 프리팹
    public float fireRate = 1f;             // 공격 간격 (초 단위)

    // Start is called before the first frame update
    private void OnEnable()
    {

        // 발사 중이 아니면 코루틴 시작
        StartCoroutine(FireSpreadAttack());
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
    // Update is called once per frame
    void Update()
    {

    }
    void Fire()
    {
        GameObject sardine = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
        sardine.transform.SetParent(gameObject.transform);
    }
}
