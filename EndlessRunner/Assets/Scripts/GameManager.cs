using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public Transform platformGeneratorManager;
    private Vector3 platformStartPosition;
    public PlayerController player;
    private Vector3 playerStartPosition;
    private PlatformDestroyer[] platformList;
    public Transform camera;
    private Vector3 cameraPosition;
   
    void Start()
    {
        platformStartPosition = platformGeneratorManager.position;
        playerStartPosition = player.transform.position;
        cameraPosition = camera.position;

    }

    public void RestartGame()
    {
        StartCoroutine("RestartCoroutine");
    }
    public IEnumerator RestartCoroutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPosition;
        platformGeneratorManager.position = platformStartPosition;
        camera.position = cameraPosition;
        player.gameObject.SetActive(true);
    }
}
