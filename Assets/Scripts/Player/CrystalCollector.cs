using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CrystalCollector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private float _duration;
    [SerializeField] private Transform _enemy;

    private Tween _move;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            crystal.transform.SetParent(_enemy);
            _move =  crystal.transform.DOLocalMove(transform.localPosition, _duration);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            float distance = Vector3.Distance(transform.position, crystal.transform.position);

            if (distance < 0.1f)
            { 
                _move.Kill();
                _particle.Play();
                Destroy(crystal.gameObject);
            }
        }
    }
}
