using UnityEngine;

namespace Game
{
    public class CameraLooker : MonoBehaviour
    {
        [SerializeField] private Vector3 _biasToLook;
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            if(_target!=null)
                transform.position = _target.position + _biasToLook;
        }
    }
}
