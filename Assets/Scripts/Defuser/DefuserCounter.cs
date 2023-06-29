using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefuserCounter : MonoBehaviour
{
    public int defuserAmount = 0;
    public int amountToWin;
    
    private void Start()
    {
        amountToWin = transform.childCount;
    }
    public void CountOneDefuser()
    {
        defuserAmount += 1;
        CheckDefuserAmount();
    }

    private void CheckDefuserAmount()
    {
        if (defuserAmount >= amountToWin)
        {
            Debug.Log("Load Win Screen");
        }
    }
}
