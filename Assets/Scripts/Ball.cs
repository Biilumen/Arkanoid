using UnityEngine;

[ExecuteAlways]
public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _previousPosition;
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _particle;

    private Vector3 _flyDirection;
    private Rigidbody _rigidbody;
    private Vector3 _reflectDirection = Vector3.back;
    private Vector3 _collisionPosition;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _previousPosition.position = transform.position;
        _rigidbody.AddForce(_reflectDirection*_speed, ForceMode.Impulse);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _flyDirection = transform.position - _previousPosition.position;
        _previousPosition.position = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.AddForce(_flyDirection * _speed, ForceMode.Impulse);
        _collisionPosition = transform.position;
        _particle.Play();
    }
}
