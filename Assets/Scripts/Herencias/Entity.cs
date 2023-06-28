using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{
    public int life;

    public virtual void TakeDamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        Destroy(gameObject);
    }
}