using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EfectButtonMenu : MonoBehaviour
{
    public void ComicScene()
    {
        SceneManager.LoadScene(1);
    }
    public void JuegoScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
