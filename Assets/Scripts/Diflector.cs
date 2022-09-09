using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Diflector : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private void Update()
    {
        //var direction = _ball.transform.position - transform.position;
       // Debug.DrawRay(transform.position, direction, Color.red);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
