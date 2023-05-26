using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public Player player;
    private int _initialLife = 3;

    public void CheckLife(int dmg)
    {
        player.life -= dmg;

        if (player.life <= 0)
        Debug.Log("Cargar escena -Game Over-");
    }

    public void SetLife()
    {
        player.life = _initialLife;
    }

    public void SetLife(int newLife)
    {
        player.life = newLife;
    }
}
