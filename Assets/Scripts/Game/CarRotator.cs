using UnityEngine;
using static Enums;

namespace Game
{
    public class CarRotator : MonoBehaviour
    {
        [SerializeField] private CarTriggerObserver _carTriggerObserver;
        [SerializeField] private DirectionRotate _directionRotate;
        [SerializeField] private float _speedRotate;
      
        private InputSystem _inputSystem;
        private bool _inRotation;
        private bool _canRotate;

        private Vector3 _goalRotateAngle;
        private DirectionRotate _nextDirection;


        private void Awake()
        {
            _inputSystem = FindObjectOfType<InputSystem>();
            _inputSystem.MouseDown += StartRotate;
            _carTriggerObserver.SetNewDirection += SetDirectionRotate;
            _directionRotate = DirectionRotate.Left;
        }

        private void OnDisable()
        {
            _inputSystem.MouseDown -= StartRotate;
            _carTriggerObserver.SetNewDirection -= SetDirectionRotate;
        }


        private void StartRotate()
        {
//        Debug.Log("Start rotayte");
            if (_canRotate)
            {
                _inRotation = true;
                _canRotate = false;
            }
        }

        public void EndRotate()
        {
            _inRotation = false;
            _canRotate = true;
            _goalRotateAngle = transform.eulerAngles + new Vector3(0, 90, 0) * (int) _directionRotate;
            if (_goalRotateAngle.y > 360)
                _goalRotateAngle -= new Vector3(0, 360, 0);
            if (_goalRotateAngle.y < 0)
                _goalRotateAngle += new Vector3(0, 360, 0);
        }

        public void SetDirectionRotate(DirectionRotate directionRotate)
        {
            if (!_inRotation)
            {
                _directionRotate = directionRotate;
                _canRotate = true;
                _goalRotateAngle = transform.eulerAngles + new Vector3(0, 90, 0) * (int) _directionRotate;
                if (_goalRotateAngle.y > 360)
                    _goalRotateAngle -= new Vector3(0, 360, 0);
                if (_goalRotateAngle.y < 0)
                    _goalRotateAngle += new Vector3(0, 360, 0);
            }
            else
            {
                _nextDirection = directionRotate;
            }
        }

        private void FixedUpdate()
        {
            if (_inRotation)
            {
                transform.eulerAngles += new Vector3(0, _speedRotate, 0) * (int) _directionRotate;
          
                if (Vector3.Distance(transform.eulerAngles, _goalRotateAngle) <= _speedRotate*2)
                {
                    transform.eulerAngles = _goalRotateAngle;
                    _directionRotate = _nextDirection;
                    EndRotate();
                }
            }
        }

    }
}