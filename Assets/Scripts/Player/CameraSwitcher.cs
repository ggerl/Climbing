using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondCamera;
    private bool mainCameraActive;

    private void Start()
    {
        CharacterManager.Instance.Player.playerController.toggleCamera += cameraChange;
    }
    private void cameraChange()
    {
        mainCameraActive = !mainCameraActive;
        mainCamera.SetActive(mainCameraActive);
        secondCamera.SetActive(!mainCameraActive);

        if (mainCamera.activeInHierarchy)
        {
            CharacterManager.Instance.Player.playerController.currentCamera = mainCamera.GetComponent<Camera>();
        }
        else
        {
            CharacterManager.Instance.Player.playerController.currentCamera = secondCamera.GetComponent<Camera>();
        }
    }



}
