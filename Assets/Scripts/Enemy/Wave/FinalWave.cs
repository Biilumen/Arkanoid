using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWave : MonoBehaviour
{
    [SerializeField] private Transform _ballposition;
    [SerializeField] private List<Rigidbody> _balls;
    [SerializeField] private Waves _waves;
    [SerializeField] private List<Animator> _animators;
    [SerializeField] private List<GameObject> _enemys;
    [SerializeField] private GroundMove _ground;

    private List<IDying> _dyings;

    public const string Final = "Final";

    private void Awake()
    {
        _dyings = new List<IDying>();

        for (int i = 0; i < _enemys.Count; i++)
        {
            _dyings.Add(_enemys[i].GetComponent<IDying>());
        }
    }
    private void OnEnable()
    {
        _waves.FinalWave += OnFinalWave;
        foreach (var dyie in _dyings)
        {
            dyie.Die += OnFinalEnemyDie;
        }
    }

    private void OnDisable()
    {
        _waves.FinalWave -= OnFinalWave;
        foreach (var dyie in _dyings)
        {
            dyie.Die += OnFinalEnemyDie;
        }
    }

    private void OnFinalWave()
    {
        for (int i = 1; i < _balls.Count; i++)
        {
            _balls[i].gameObject.SetActive(false);
        }

        StartCoroutine(BallMove());
    }

    private IEnumerator BallMove()
    {
        _balls[0].velocity = Vector3.zero;
        _balls[0].transform.position = _ballposition.position;
        yield return new WaitForSeconds(0.5f);
        _balls[0].AddForce(Vector3.back * 2, ForceMode.Impulse);
    }

    private void OnFinalEnemyDie()
    {
        foreach(var animator in _animators)
        {
            animator.SetTrigger(Final);
        }

        _ground.Stop();
    }
}
