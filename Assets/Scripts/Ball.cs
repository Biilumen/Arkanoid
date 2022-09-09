using UnityEngine;

[ExecuteAlways]
public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _previousPosition;

    private Vector3 _flyDirection;
    private Rigidbody _rigidbody;
    private Vector3 _reflectDirection = Vector3.zero;
    private Vector3 _collisionPosition;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.back * 3f,ForceMode.VelocityChange);
        _previousPosition.position = transform.position;
    }

    private void Update()
    {
        _flyDirection = transform.position - _previousPosition.position;
        _previousPosition.position = transform.position;
        Debug.DrawRay(transform.position, _flyDirection * 100, Color.red);
        Debug.DrawRay(_collisionPosition, _reflectDirection.normalized  * 100, Color.blue);
        print(_rigidbody.velocity);
        _rigidbody.MovePosition( transform.position + _reflectDirection * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var reflect = Vector3.Reflect(_flyDirection, collision.transform.forward);
        _reflectDirection = reflect;
        _collisionPosition = transform.position;
        print("“ÛÍ");
    }
}
