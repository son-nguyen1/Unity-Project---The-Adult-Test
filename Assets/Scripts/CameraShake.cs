using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera m_VirtualCamera;
    private CinemachineBasicMultiChannelPerlin m_MultiChannelPerlin;

    private float shakeIntensity = 10f;
    private float shakeTotalTime = 0.5f;

    private float currentTime;

    private void Awake()
    {
        m_VirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        StopShake();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                StopShake();
            }
        }
    }

    public void ShakeCamera()
    {
        StartShake();
    }

    private void StartShake()
    {
        m_MultiChannelPerlin = m_VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        m_MultiChannelPerlin.m_AmplitudeGain = shakeIntensity;

        currentTime = shakeTotalTime; // Set timer to control shake duration
    }

    private void StopShake()
    {
        m_MultiChannelPerlin = m_VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        m_MultiChannelPerlin.m_AmplitudeGain = 0f;

        currentTime = 0f; // Reset timer to stop shaking
    }
}