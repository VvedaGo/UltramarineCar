using UnityEngine;

namespace Game.Car
{
    public class CarMover : MonoBehaviour
    {
        public float moveSpeed = 2f;

        private void Update()
        {
        
            Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
            transform.position += forwardDirection * moveSpeed * Time.deltaTime;
    
      
        }
    }
}
