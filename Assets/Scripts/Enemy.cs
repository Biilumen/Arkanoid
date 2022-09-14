using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int Heath;
    [SerializeField] protected RayfireBomb Rayfire;
    [SerializeField] protected Transform Plane;
    [SerializeField] protected RayfireRigidRoot RayfireRoot;
    [SerializeField] protected List<Transform> EnemyTransforms;
    [SerializeField] private List<Rigidbody> _rigidbodies;

    protected BoxCollider BoxCollider;
    protected Animator Animator;

    protected void Start()
    {
        Animator = GetComponent<Animator>();
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

    protected virtual void TakeDamage()
    {
        Heath--;

        if (Heath <= 0)
        {
            RayfireRoot.Initialize();
            Rayfire.Explode(0f);
            BoxCollider.enabled = false;
            Animator.enabled = false;

            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
        }
    }
}