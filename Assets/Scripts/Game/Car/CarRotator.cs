using Infrastructure.Services;
using UnityEngine;
using static Enums;

namespace Game.Car
{
    public class CarRotator : MonoBehaviour
    {
        [SerializeField] private CarTriggerObserver _carTriggerObserver;
        [SerializeField] private DirectionRotate _directionRotate;
        [SerializeField] private float _speedRotate;

        private InputSystem _inputSystem;
        private bool _inRotation;
        private bool _canRotate;
        private bool _usedLastRotation = true;
        private DirectionRotate _directionToSetAfterRotate;

        private Vector3 _goalRotateAngle;
        private DirectionRotate _nextDirection;

        private ParameterCarBeforeRotate _parameterCarBeforeRotate;
        public bool IsDeath;

        private void Awake()
        {
            _inputSystem = FindObjectOfType<InputSystem>();
            _inputSystem.MouseDown += StartRotate;
            _carTriggerObserver.SetNewDirection += SetDirectionRotate;
            _directionRotate = DirectionRotate.Left;
            _parameterCarBeforeRotate = new ParameterCarBeforeRotate();
        }

        private void OnDisable()
        {
            //  _inputSystem.MouseDown -= StartRotate;
            //  _carTriggerObserver.SetNewDirection -= SetDirectionRotate;
        }


        private void StartRotate()
        {
//        Debug.Log("Start rotayte");
            if (_canRotate&&!IsDeath)
            {
                _parameterCarBeforeRotate.Position = transform.position;
                _parameterCarBeforeRotate.Rotation = transform.eulerAngles;
                Debug.Log(JsonUtility.ToJson(_parameterCarBeforeRotate));
                _inRotation = true;
                _canRotate = false;
            }
        }

        public void SetParameterAfterRelive()
        {
            Debug.Log(JsonUtility.ToJson(_parameterCarBeforeRotate));
            transform.position = _parameterCarBeforeRotate.Position;
            transform.eulerAngles = _parameterCarBeforeRotate.Rotation;
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
               // Debug.Log("!In rot");
                if (_usedLastRotation)
                {
                  //  Debug.Log("if");
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
                  //  Debug.Log("Elseee");
                        _nextDirection = directionRotate;
                  //  _usedLastRotation = true;
                }

               
            }
            else
            {
//                Debug.Log("Else");
                _usedLastRotation = true;
                _nextDirection = directionRotate;
            }
        }

        private void FixedUpdate()
        {
            if (_inRotation)
            {
                transform.eulerAngles += new Vector3(0, _speedRotate, 0) * (int) _directionRotate;

                if (Vector3.Distance(transform.eulerAngles, _goalRotateAngle) <= _speedRotate )
                {
                    transform.eulerAngles = _goalRotateAngle;
                    _directionRotate = _nextDirection;
                    _usedLastRotation = true;
                    EndRotate();
                }
            }
        }
    }
}