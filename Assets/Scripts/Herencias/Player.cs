using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected LifeController lifeController;
    private void Start()
    {
        lifeController = GetComponent<LifeController>();
        lifeController.SetLife();
    }
    
    public override void TakeDamage(int dmg)
    {
        lifeController.CheckLife(dmg);
    }
}