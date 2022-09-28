using System;
using UnityEngine;

public class LongEnemy : Enemy, IDying
{
    [SerializeField] private Material _gap;
    [SerializeField] private MeshRenderer _boxRenderer;

    public event Action Die;

    public override void TakeDamage()
    {
        base.TakeDamage();

        if (HealthPoints >= 1)
        {
            _boxRenderer.material = _gap;
        }

        if (HealthPoints <= 0)
        {
            Die?.Invoke();
        }
    }
}
