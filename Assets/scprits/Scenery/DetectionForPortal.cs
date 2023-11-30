using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectionForPortal : MonoBehaviour
{
    [SerializeField]
    GameObject portal;
    bool confirmer = true;

    private void Start()
    {
        portal.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TruePortal());
            if (confirmer)
            {
                ControlMove();
                StartCoroutine(TrueMoveCam());
            }
        }
    }
    public void ControlMove()
    {
        EfectoCam.Instance.MoverCam(5, 4, 5);
    }
    IEnumerator TrueMoveCam()
    {
        yield return new WaitForSeconds(4);
        confirmer = false;
    }
    IEnumerator TruePortal()
    {
        yield return new WaitForSeconds(5);
        portal.SetActive(true);
    }
}
