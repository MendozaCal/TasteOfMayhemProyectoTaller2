using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinue : MonoBehaviour
{
    [SerializeField]
    GameObject desactivar;
    void Start()
    {
        StartCoroutine(Button());
    }
    IEnumerator Button()
    {
        desactivar.SetActive(false);
        yield return new WaitForSeconds(33);
        desactivar.SetActive(true);
    }
}
}
