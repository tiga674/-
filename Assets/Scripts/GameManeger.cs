using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    bool blockDrop1Flg = true;

    public float blockDrop1Interval;
    public GameObject block1;

    void Start()
    {
        StartCoroutine(blockDrop1());
    }
   
    void Update()
    {
        
    }

    //ブロックを一定の間隔で落とす
    private IEnumerator blockDrop1()
    {
        while (blockDrop1Flg)
        {
            yield return new WaitForSeconds(blockDrop1Interval);

            int x = Random.Range(-2, 4);
            int z = Random.Range(-2, 4);

            Instantiate(
                block1,
                new Vector3(x, 20, z),
                Quaternion.identity);
        }
    }
}
