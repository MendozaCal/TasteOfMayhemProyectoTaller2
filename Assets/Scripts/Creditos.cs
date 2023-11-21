using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI timerText;

    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Timer());
        StartCoroutine(WaitToEnd());
    }

    IEnumerator Timer()
    {
        int count = 0;
        while (true)
        {
            timerText.text = $"Timer: {count}";
            yield return new WaitForSeconds(1);
            count++;
        }
    }
    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(5); 
        SceneManager.LoadScene("Menu");
    }
}
