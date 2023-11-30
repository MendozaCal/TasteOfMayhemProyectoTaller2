using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public string GameOverScene;
    public float delay = 1f;
    public void BotonJugar()
    {
        Invoke("CambiarEscena", delay);
    }

    public void BotonSalir()
    {
        Debug.Log("Saliste");
        Application.Quit();
    }
    private void CambiarEscena()
    {
        // Cambiar a la escena Game Over
        SceneManager.LoadScene(GameOverScene);
    }
}
