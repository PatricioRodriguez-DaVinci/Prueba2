using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int life;

    public virtual void TakeDamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        Destroy(gameObject);
    }
}