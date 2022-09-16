using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(BoxCollider))]
public class LongEnemy : Enemy
{
    [SerializeField] private Material _gap;
    [SerializeField] private GameObject _cube;
    [SerializeField] private MeshRenderer _boxRenderer;

    public override void TakeDamage()
    {
        if (Health >= 1)
        {
            _boxRenderer.material = _gap;
        }
        base.TakeDamage();
    }
}
