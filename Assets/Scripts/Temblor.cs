using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Temblor : MonoBehaviour
{
    public static EfectoCam Instance;
    CinemachineVirtualCamera cam;
    CinemachineBasicMultiChannelPerlin vibracion;
    float duraci�n;
    float tiempomax;
    float intencidadinicial;
    void Awake()
    {
        Instance = this;
        cam = GetComponent<CinemachineVirtualCamera>();
        vibracion = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


    void Update()
    {
        if (tiempomax > 0)
        {
            tiempomax -= Time.deltaTime;
            vibracion.m_AmplitudeGain = Mathf.Lerp(intencidadinicial, 0, 1 - (duraci�n / tiempomax));
        }
    }
    public void MoverCam(float fuerza, float frecuencia, float tiempo)
    {
        vibracion.m_AmplitudeGain = fuerza;
        vibracion.m_FrequencyGain = frecuencia;
        intencidadinicial = fuerza;
        tiempomax = tiempo;
        duraci�n = tiempo;
    }
}
