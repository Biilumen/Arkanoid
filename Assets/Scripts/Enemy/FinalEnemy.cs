using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FinalEnemy : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private ParticleSystem _confettyParticle;
    [SerializeField] private SpriteRenderer _multiplier;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            _confettyParticle.Play();
            Destroy(gameObject);
            Destroy(collision.gameObject);

            _multiplier.transform.DOMoveY(_multiplier.transform.position.y + 0.5f, _duration);
            _multiplier.DOFade(0, _duration).SetDelay(_duration);
        }
    }
}