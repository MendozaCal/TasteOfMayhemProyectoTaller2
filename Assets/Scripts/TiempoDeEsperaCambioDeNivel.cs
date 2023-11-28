using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TiempoDeEsperaCambioDeNivel : MonoBehaviour
{
    private TextMeshProUGUI Texto;
    public float TimeCron;
    void Awake()
    {
        Texto = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        TimeCron -= Time.deltaTime;
        int t = (int)TimeCron;
        int Minutes = t / 60;
        int Seconds = t % 60;
        Texto.SetText($"{Minutes}:{Seconds}");
    }
  /*IEnumerator Timer()
    {
        int count = 0; 
        while (true)
        {
            Texto = $"Timer: {count}";
            yield return new WaitForSeconds(1);
            count++;
        }
    }*/
    // M�todo para activar el cambio de escena despu�s de la pantalla de puntaje
    public void ActivarCambioDeEscena()
    {
        StartCoroutine(WaitAndChangeScene());
    }

    IEnumerator WaitAndChangeScene()
    {
        // Espera por unos segundos (ajusta seg�n sea necesario)
        yield return new WaitForSeconds(5);

        // Cambia a la escena de puntuaci�n o a la que desees
        SceneManager.LoadScene("Menu");
    }
}
