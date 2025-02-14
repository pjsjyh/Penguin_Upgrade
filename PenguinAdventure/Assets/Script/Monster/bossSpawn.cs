using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpawn : MonoBehaviour
{
    public List<GameObject> bossMonsterObj;
    // Start is called before the first frame update

    public void spawn(int num)
    {
        Instantiate(bossMonsterObj[num], gameObject.transform.position, Quaternion.identity);
    }
}
