using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTimeButtonContinue : MonoBehaviour
{
    [SerializeField]
    GameObject desactivar;
    public float WaitTime;
    void Start()
    {
        StartCoroutine(Button());
    }
    IEnumerator Button()
    {
        desactivar.SetActive(false);
        yield return new WaitForSeconds(WaitTime);
        desactivar.SetActive(true);
    }
}
