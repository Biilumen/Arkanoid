using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private GroundMove _groundMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Deliter deliter))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _boxCollider.bounds.size.z * _groundMove.PlaneListCount);  
        }
        
    }
}