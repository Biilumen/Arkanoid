using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _size;
    [SerializeField] private ParticleSystem _colisionParticle;
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private PowerUp _firePowerUp;
    [SerializeField] private SizeUp _sizeUp;

    private Rigidbody _rigidbody;
    private Vector3 _reflectDirection = Vector3.back;

    private void OnEnable()
    {
        _firePowerUp.PowerUped += PowerUp;
        _sizeUp.SizeUped += SizeUp;
    }

    private void OnDisable()
    {
        _firePowerUp.PowerUped -= PowerUp;
        _sizeUp.SizeUped -= SizeUp;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(_reflectDirection*_speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.zero;
        _reflectDirection =  Vector3.Reflect(_reflectDirection, collision.contacts[0].normal);
        _rigidbody.AddForce(_reflectDirection.normalized * _speed, ForceMode.Impulse);
        _colisionParticle.Play();
    }

    private void PowerUp()
    {
        _fireParticle.Play();
    }

    private void SizeUp()
    {
        transform.localScale = transform.localScale * _size;
    }
}
