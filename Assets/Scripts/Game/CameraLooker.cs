using DG.Tweening;
using Game.Car;
using UnityEngine;
using static Enums;

namespace Game
{
    public class CameraLooker : MonoBehaviour
    {
        [SerializeField] private Vector3 _biasToLook;
        private Transform _target;
        [SerializeField] Transform cameraTransform;

        [SerializeField] private CarTriggerObserver _carTriggerObserver;

        int targetAngle = 0;

        public void SetTarget(Transform target)
        {
            Debug.Log("SetTarget cast");
            _carTriggerObserver = GameObject.FindObjectOfType<CarTriggerObserver>();

            _carTriggerObserver.SetNewDirection += SetDirectionRotate;

            _target = target;
        }

        private void LateUpdate()
        {
            if (_target != null)
            {
                transform.position = _target.position;

                cameraTransform.localPosition = _biasToLook;

                
            }
        }

        public void SetDirectionRotate(DirectionRotate directionRotate)
        {
            if (directionRotate == DirectionRotate.Left)
                targetAngle += 60;
            else if (directionRotate == DirectionRotate.Right)
                targetAngle -= 60;

            transform.DORotate(new Vector3(0, targetAngle, 0), 5);
        }
    }
}
