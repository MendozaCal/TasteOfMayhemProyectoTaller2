using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunePlayer : MonoBehaviour
{
    MovePlayer playerMove;
    [SerializeField]
    float timeStune;

    private void Start()
    {
        playerMove = GetComponent<MovePlayer>();
    }
    public void Stun(Vector2 position)
    {
        playerMove.Rebote(position);
        //StartCoroutine(stuneMoment());
    }
    IEnumerator stuneMoment()
    {
        playerMove.isMoving = false;
        yield return new WaitForSeconds(timeStune);
        playerMove.isMoving = true;
    }
}
