using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] private float _scale;

    private void Update()
    {
        Time.timeScale = _scale;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
