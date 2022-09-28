using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal";
    
    [SerializeField] private float _spead;

    private Vector3 _playerPosition;

    private void Start()
    {
        _playerPosition = transform.position;
    }

    private void Update()
    {
        _playerPosition.x += Input.GetAxis(AxisHorizontal) * _spead * Time.deltaTime;

        transform.position = _playerPosition;
    }
}