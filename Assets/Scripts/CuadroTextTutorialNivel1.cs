using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadroTextTutorialNivel1 : MonoBehaviour
{
    [SerializeField]
    GameObject cuadrodetexto1;
    [SerializeField]
    GameObject cuadrotexto2;
    Transform move;
    GameObject player;
    private void Start()
    {
        cuadrodetexto1.SetActive(false);
        cuadrotexto2.SetActive(false);
        StartCoroutine(ifnopress());
        move = FindAnyObjectByType<MovePlayer>().transform;
        player.GetComponent<ShootMouse>().enabled = false;
    }
    public void continuebutton()
    {
        cuadrodetexto1.SetActive(false);
        StartCoroutine(ActiveSecondButton());
    }
    public void continuebutton2()
    {
        cuadrotexto2.SetActive(false);
    }
    IEnumerator ifnopress()
    {
        yield return new WaitForSeconds(4);
        cuadrodetexto1.SetActive(true);
        yield return new WaitForSeconds(8);
        cuadrodetexto1.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        cuadrotexto2.SetActive(true);
        yield return new WaitForSeconds(8);
        cuadrotexto2.SetActive(false);
    }
    IEnumerator ActiveSecondButton()
    {
        yield return new WaitForSeconds(0.5f);
        cuadrotexto2.SetActive(true);
        yield return new WaitForSeconds(8);
        cuadrotexto2.SetActive(false);
    }
}
