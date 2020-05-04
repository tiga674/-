using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool blockDropFlg = true;
    bool gameLevel2Reject = false;
    bool gameLevel3Reject = false;
    float playTime = 0f;
    GameObject dropBlock;

    public float blockDropInterval;
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public Camera mainCamera;
    public Camera subCamera;

    void Start()
    {
        dropBlock = block1;
        StartCoroutine(blockDrop());
    }

    void FixedUpdate()
    {
        //時間が経過する
        playTime += Time.deltaTime;
        //Debug.Log(playTime);

        //時間経過で難易度が上がる
        if (playTime >= 20f && playTime <= 70f)
        {
            gameLevel2();
        }
        else if (playTime > 70f)
        {
            gameLevel3();
        }

        //カメラを切り替える
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!subCamera.enabled)
            {
                subCamera.enabled = true;
                mainCamera.enabled = false;
            }
            else
            {
                subCamera.enabled = false;
                mainCamera.enabled = true;
            }
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
    void gameLevel2()
    {
        if (gameLevel2Reject) { return; }
        else
        {
            dropBlock = block2;
            blockDropInterval -= 2;
            gameLevel2Reject = true;
        }
    }

    void gameLevel3()
    {
        if (gameLevel3Reject) { return; }
        else
        {
            dropBlock = block3;
            blockDropInterval -= 2;
            gameLevel3Reject = true;
        }
    }

    public void titleButtonClick()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
