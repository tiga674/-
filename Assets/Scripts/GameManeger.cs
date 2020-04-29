using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    bool blockDropFlg = true;
    bool gameLevelUpReject = false;
    float playTime = 0f;
    GameObject dropBlock;

    public float blockDropInterval;
    public GameObject block1;
    public GameObject block2;

    void Start()
    {
        dropBlock = block1;
        StartCoroutine(blockDrop());
    }
   
    void FixedUpdate()
    {
        //時間が経過する
        playTime += Time.deltaTime;

        //時間経過で難易度が上がる
        if (playTime >= 50f)
        {
            if (gameLevelUpReject) { return; }

            gameLevelUp();
        }
    }

    //ブロックを一定の間隔で落とす
    private IEnumerator blockDrop()
    {
        while (blockDropFlg)
        {
            yield return new WaitForSeconds(blockDropInterval);

            int x = Random.Range(-2, 4);
            int z = Random.Range(-2, 4);

            Instantiate(
                dropBlock,
                new Vector3(x, 20, z),
                Quaternion.identity);
        }
    }

    //ブロックの落下スピードが上昇し、落下間隔が早くなる
    void gameLevelUp()
    {
        dropBlock = block2;
        blockDropInterval -= 2;
        gameLevelUpReject = true;
    }
}
