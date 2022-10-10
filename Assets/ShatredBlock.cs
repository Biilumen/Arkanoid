using System.Collections;
using UnityEngine;

public class ShatredBlock : MonoBehaviour
{
    [SerializeField] private Transform _ground;
    [SerializeField] private float _destroyTime;

    private Rigidbody _rigidbody;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Plane plane))
        {
            transform.SetParent(_ground);
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        float time = 0f;
        while (time <= _destroyTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        if (time > _destroyTime)
        {
            Destroy(gameObject);
        }
    }
}