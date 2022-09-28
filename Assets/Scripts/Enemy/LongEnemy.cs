using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class LongEnemy : Enemy, IDying
{
    [SerializeField] private Material _gap;
    [SerializeField] private GameObject _cube;
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
