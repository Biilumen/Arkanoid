using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int Health;
    [SerializeField] protected GameObject Cube;
    [SerializeField] protected RayfireBomb Rayfire;
    [SerializeField] protected Transform Plane;
    [SerializeField] protected RayfireRigidRoot RayfireRoot;
    [SerializeField] protected List<Transform> EnemyTransforms;
    [SerializeField] protected Material DeadEnemyMaterial;
    [SerializeField] protected List<SkinnedMeshRenderer> DeadEnemyMeshRenderers;
    [SerializeField] protected List<Animator> Animators;
    [SerializeField] protected BombEnemy BombEnemy;
    [SerializeField] private List<Rigidbody> _rigidbodies;

    protected BoxCollider BoxCollider;

    protected void Start()
    {
        BoxCollider = GetComponent<BoxCollider>();

        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            TakeDamage();
        }
    }

    public virtual void TakeDamage()
    {
        Health--;

        if (Health <= 0)
        {
            RayfireRoot.Initialize();
            Rayfire.Explode(0f);
            BoxCollider.enabled = false;
            Destroy(Cube.gameObject);

            foreach (var animator in Animators)
            {
                animator.enabled = false;
            }

            foreach(var deadEnemyMeshRenderer in DeadEnemyMeshRenderers) 
            {
                deadEnemyMeshRenderer.material = DeadEnemyMaterial;
            }

            foreach (var transform in EnemyTransforms)
            {
                transform.SetParent(Plane);
            }

            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
        }
    }
}