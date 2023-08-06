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

        float targetAngle = 0;

        Transform myCar;

        public void SetTarget(Transform target, Car.Car car)
        {
            myCar = car.transform;

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
                targetAngle = myCar.eulerAngles.y + 60;
            else if (directionRotate == DirectionRotate.Right)
                targetAngle = myCar.eulerAngles.y + -60; ;

            transform.DORotate(new Vector3(0, targetAngle, 0), 5);
        }
    }
}
