using UnityEngine;

public class RootDestroy : MonoBehaviour
{
    [SerializeField] private Transform _root;
    [SerializeField] private Transform _cube;

    private void OnDestroy()
    {
        Destroy(_cube.gameObject);
        Destroy(_root.gameObject);
    }
}
