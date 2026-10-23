using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAllow : MonoBehaviour
{
    public CharacterSelectEventSo player;
    private CinemachineVirtualCamera vcam;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        vcam.Follow = player.player1.transform;
        vcam.LookAt = player.player1.transform;
    }
}
