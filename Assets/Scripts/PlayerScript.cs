using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private CameraScript cameraScript;
    private AudioSource clearSound;

    public Text stateText;
    public GameObject gameManager;
    public GameObject mainCamera;
    public GameObject SE;

    void Start()
    {
        cameraScript = mainCamera.GetComponent<CameraScript>();
        clearSound = SE.GetComponent<AudioSource>();
    }

    //当たり判定の処理
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            gameManager.SetActive(false);
            Destroy(this.gameObject);
            cameraScript.enabled = false;
            stateText.text = "GameOver!!";
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Goal")
        {
            gameManager.SetActive(false);
            clearSound.Play();
            Destroy(this.gameObject);
            cameraScript.enabled = false;
            stateText.text = "GameClear!!";
        }
    }
}
