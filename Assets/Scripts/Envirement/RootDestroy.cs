using UnityEngine;

public class RootDestroy : MonoBehaviour
{
    [SerializeField] private Transform _root;

    private void OnDestroy()
    {
        Destroy(_root.gameObject);
    }
}
