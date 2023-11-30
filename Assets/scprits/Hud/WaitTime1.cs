using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTime1 : MonoBehaviour
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
        player.GetComponent<MovePlayer>().canMove = false;
        objetocreado.SetActive(false);
        yield return new WaitForSeconds(3);
        objetocreado.SetActive(true);
        yield return new WaitForSeconds(8);
        objetocreado.SetActive(false);
        player.GetComponent<MovePlayer>().canMove = true;
    }
}
