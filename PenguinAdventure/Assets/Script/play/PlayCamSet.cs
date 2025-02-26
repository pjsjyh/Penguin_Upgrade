using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayCamSet : MonoBehaviour
{
    // Start is called before the first frame update
    private CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        virtualCamera = this.GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = GameManager.Instance.playerInstance.transform;
    }

    
}
