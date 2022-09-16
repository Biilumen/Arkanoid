using System;
using System.Collections.Generic;
using UnityEngine;

public class ShortEnemy : Enemy
{
    public event Action<ShortEnemy> Dead;

    public override void TakeDamage()
    {
        base.TakeDamage();
        Dead?.Invoke(this);
    }
}