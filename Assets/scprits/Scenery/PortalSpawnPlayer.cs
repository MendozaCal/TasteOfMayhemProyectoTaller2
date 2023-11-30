using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawnPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject portal;
    [SerializeField]
    GameObject prota;
    void Start()
    {
        prota.SetActive(false);
        portal.SetActive(false);
        StartCoroutine(portalaparicion());
    }
    IEnumerator portalaparicion()
    {
        yield return new WaitForSeconds(1);
        portal.SetActive(true);
        StartCoroutine (protaparicion());
        yield return new WaitForSeconds(2);
        portal.SetActive(false);
    }
    IEnumerator protaparicion()
    {
        yield return new WaitForSeconds(1);
        prota.SetActive(true);
    }
}
