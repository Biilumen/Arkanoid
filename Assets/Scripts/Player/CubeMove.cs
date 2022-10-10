using UnityEngine;
using UnityEngine.Playables;

public class CubeMove : MonoBehaviour
{
   [SerializeField] private PlayableDirector _playableDirector;

   private void OnCollisionEnter(Collision collision)
   {
      if(collision.gameObject.TryGetComponent(out Ball ball))
         _playableDirector.Play();
   }
}
