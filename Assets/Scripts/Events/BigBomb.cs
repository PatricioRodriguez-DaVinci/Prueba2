using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBomb : MonoBehaviour
{
    public delegate void EventBigBomb(int num);

    public EventBigBomb bigBombEvent;

    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
    {
        BigExplotion(100);
        Debug.Log("La gran explosion");
    }

    void BigExplotion(int num)
    {
        if (bigBombEvent != null)
        bigBombEvent(num);
    }

    }
}