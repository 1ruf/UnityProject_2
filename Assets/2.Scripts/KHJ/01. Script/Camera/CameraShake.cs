using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    Vector2 originPos;
    CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private Entity _entity;


    private void Awake()
    {

        if (instance == null) instance = this;
        else Destroy(this);

        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

}
