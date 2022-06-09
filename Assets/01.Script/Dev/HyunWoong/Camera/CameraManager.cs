using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public CinemachineVirtualCamera _cmPlayerCam;
    public CinemachineVirtualCamera _cmNpcCam;
    public CinemachineVirtualCamera _cmDoorOpenCam;
    public CinemachineVirtualCamera _cmOpenCam;
    public CinemachineVirtualCamera _cmPlayCam;

    public CinemachineVirtualCamera _cmObeCam;

    private CinemachineVirtualCamera _activeCam = null;
    private CinemachineBasicMultiChannelPerlin _activePerlin = null;

    private CinemachineBasicMultiChannelPerlin _actionPerlin = null;

    private const int backPriority = 10;
    private const int frontPriority = 15;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple CameraManager instance is running");
        }
        instance = this;

        _actionPerlin = _cmDoorOpenCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCam(float intensity, float time)
    {
        if (_activeCam == null || _activePerlin == null) return;
        StopAllCoroutines();
        StartCoroutine(ShakeCamCoroutine(intensity, time));
    }
    IEnumerator ShakeCamCoroutine(float intensity, float endtime)
    {
        _activePerlin.m_AmplitudeGain = intensity;

        float currentTime = 0f;
        while (currentTime < endtime)
        {
            yield return null;
            if (_activePerlin == null) break;
            _activePerlin.m_AmplitudeGain
                = Mathf.Lerp(intensity, 0f, currentTime / endtime);
            currentTime += Time.deltaTime;
        }
        if (_activePerlin != null)
        {
            _activePerlin.m_AmplitudeGain = 0;
        }
    }

    public void SetNpcCamActive()
    {
        _cmNpcCam.Priority = frontPriority;
        _cmPlayerCam.Priority = backPriority;
        _cmOpenCam.Priority = backPriority;

        _activeCam = _cmNpcCam;
        _activePerlin = null;
    }

    public void SetPlayerCamActive()
    {
        _cmPlayerCam.Priority = frontPriority;
        _cmNpcCam.Priority = backPriority;
        _cmOpenCam.Priority = backPriority;
        _cmPlayCam.Priority = backPriority;
        _cmObeCam.Priority = backPriority;

        _cmPlayerCam.m_Lens.OrthographicSize = Mathf.Lerp(5f, 3.5f, 1f);

        _activeCam = _cmPlayerCam;
        _activePerlin = null;
    }

    public void SetActionCamActive()
    { 
        _cmPlayerCam.Priority = backPriority;
        _cmNpcCam.Priority = backPriority;
        _cmDoorOpenCam.Priority = frontPriority;
        _cmOpenCam.Priority = backPriority;
        _cmObeCam.Priority = backPriority;

        _activeCam = _cmDoorOpenCam;
        _activePerlin = _actionPerlin;
    }

    public void SetOpenCam()
    {
        _cmPlayerCam.Priority = backPriority;
        _cmNpcCam.Priority = backPriority;
        _cmDoorOpenCam.Priority = backPriority;
        _cmOpenCam.Priority = frontPriority;
        _cmObeCam.Priority = backPriority;
        print(_cmOpenCam.Priority);

        _activeCam = _cmOpenCam;
        _activePerlin = null;

    }

    public void SetPlayCam()
    {
        _cmPlayerCam.Priority = backPriority;
        _cmNpcCam.Priority = backPriority;
        _cmDoorOpenCam.Priority = backPriority;
        _cmOpenCam.Priority = backPriority;
        _cmPlayCam.Priority = frontPriority;
        _cmObeCam.Priority = backPriority;

        _activeCam = _cmPlayCam;
        _activePerlin = null;
    }

    public void SetObeCam()
    {
        _cmPlayerCam.Priority = backPriority;
        _cmNpcCam.Priority = backPriority;
        _cmDoorOpenCam.Priority = backPriority;
        _cmOpenCam.Priority = backPriority;
        _cmPlayCam.Priority = backPriority;
        _cmObeCam.Priority = frontPriority;

        _activeCam = _cmObeCam;
        _activePerlin = null;
    }
}
