
using UnityEngine;

public class IcezoneSkill : MonoBehaviour
{
    public GameObject bulletPrefab;         // 총알 프리팹
    // public float fireRate = 1f;             // 공격 간격 (초 단위)

    // Start is called before the first frame update
    private void OnEnable()
    {

        GameObject icezone = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);

        icezone.transform.SetParent(gameObject.transform);
        Vector3 newPosition = icezone.transform.position;
        newPosition.z = -1; // z 값을 원하는 위치로 설정
        icezone.transform.position = newPosition;
        // isFiring = true;
    }

}
