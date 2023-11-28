using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTutorial : MonoBehaviour
{
    [SerializeField]
    GameObject objetocreado;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(ifnopress());
    }
    public void continuebutton()
    {
        objetocreado.SetActive(false);
        player.GetComponent<MovePlayer>().canMove = true;
    }
    IEnumerator ifnopress()
    {
        objetocreado.SetActive(false);
        player.GetComponent<MovePlayer>().canMove = false;
        yield return new WaitForSeconds(1);
        objetocreado.SetActive(true);
        yield return new WaitForSeconds(8);
        objetocreado.SetActive(false);
        player.GetComponent<MovePlayer>().canMove = true;
    }
}
