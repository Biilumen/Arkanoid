using System;
using System.Collections.Generic;
using UnityEngine;

public class ShortEnemy : Enemy,IDying
{
    public event Action<ShortEnemy> Dead;

    public event Action Die;

    public override void TakeDamage()
    {
        base.TakeDamage();
        Dead?.Invoke(this);
        Die?.Invoke();
    }
}