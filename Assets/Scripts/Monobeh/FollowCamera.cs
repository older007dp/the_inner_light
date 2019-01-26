using DefaultNamespace;
using UnityEngine;

namespace Monobeh
{
    public class FollowCamera : MonoBehaviour
    {
        private float Distance;
            
        private void Awake()
        {
            DI.Add<FollowCamera>(this);
        }

        public void NotifyPosition(Vector3 pos)
        {
            if (Distance == 0f)
            {
                Distance = Vector3.Distance(pos, transform.position);
            }

            var position = pos - Distance * transform.forward;
            transform.position = position;
        }
    }
}