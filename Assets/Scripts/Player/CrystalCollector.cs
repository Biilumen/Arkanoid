using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class CrystalCollector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private float _duration;
    [SerializeField] private Transform _enemy;

    private List<Tween> _moves;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            crystal.transform.SetParent(_enemy);
            _moves.Add(crystal.transform.DOLocalMove(transform.localPosition, _duration));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            float distance = Vector3.Distance(transform.position, crystal.transform.position);

            if (distance < 0.1f)
            {
                _particle.Play();
                Destroy(crystal.gameObject);
            }
        }
    }
}
