using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using RayFire;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider))]
public abstract class Enemy : MonoBehaviour
{
    [FormerlySerializedAs("Cuberoot")] [SerializeField] protected Transform CubeRoot;
    [FormerlySerializedAs("_rigidbodies")] [SerializeField] protected List<Rigidbody> Rigidbodies;
    [SerializeField] protected float Offset;
    [SerializeField] protected int HealthPoints;
    [SerializeField] protected float Duration;
    [SerializeField] protected GameObject Cube;
    [SerializeField] protected RayfireBomb Rayfire;
    [SerializeField] protected Transform Plane;
    [SerializeField] protected RayfireRigidRoot RayfireRoot;
    [SerializeField] protected List<Transform> EnemyTransforms;
    [SerializeField] protected Material DeadEnemyMaterial;
    [SerializeField] protected List<SkinnedMeshRenderer> DeadEnemyMeshRenderers;
    [SerializeField] protected List<Animator> Animators;
    [SerializeField] protected List<Transform> BlocksTransforms;
    
    protected BoxCollider BoxCollider;

    protected void Start()
    {
        BoxCollider = GetComponent<BoxCollider>();

        foreach (var rigidbody in Rigidbodies)
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
        HealthPoints--;

        if (HealthPoints <= 0)
        {
            RayfireRoot.Initialize();
            Rayfire.Explode(0f);
            BoxCollider.enabled = false;
            Destroy(Cube.gameObject);

            foreach (var block in BlocksTransforms)
            {
                block.transform.DOMoveY(block.transform.position.y + Offset, Duration);
            }

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

            foreach (var rigidbody in Rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
            
            CubeRoot.SetParent(null);
        }
    }
}