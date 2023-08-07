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
            _directionRotate = DirectionRotate.None;
            _parameterCarBeforeRotate = new ParameterCarBeforeRotate();
        }

        private void OnDisable()
        {
            //  _inputSystem.MouseDown -= StartRotate;
            //  _carTriggerObserver.SetNewDirection -= SetDirectionRotate;
        }


        public void SetParameterAfterRelive()
        {
        
            transform.position = _parameterCarBeforeRotate.Position;
            transform.eulerAngles = _parameterCarBeforeRotate.Rotation;
        }

        private void StartRotate()
        {
//        Debug.Log("Start rotayte");
            if (!_inRotation&&!IsDeath)
            {
                _parameterCarBeforeRotate.Position = transform.position;
                _parameterCarBeforeRotate.Rotation = transform.eulerAngles;
             //   Debug.Log(JsonUtility.ToJson(_parameterCarBeforeRotate));
                _inRotation = true;
               // _canRotate = false;
               // _usedLastRotation = true;
            }
        }

        private bool _useNextDirection;
        public void EndRotate()
        {
           
            //_canRotate = true;

            Debug.Log("End rotate "+ _useNextDirection);
            if (_useNextDirection)
            {
                _directionRotate = _nextDirection;
                _useNextDirection = false;
                SetNextGoalRotation();
            }
            else
            {
                _usedLastRotation = true;
            }

            
          
           
           
        }

        public void SetDirectionRotate(DirectionRotate directionRotate)
        {
            if(directionRotate==DirectionRotate.None)
                return;
            
            Debug.Log("Set new direction "+ directionRotate);
            if (_usedLastRotation)
            {
                Debug.Log("If qwe");
              
                _directionRotate = directionRotate;
              
               // _canRotate = true;
                SetNextGoalRotation();
                _usedLastRotation = false;
            }
            else
            {
                Debug.Log("Else");
                _useNextDirection = true;
                    _nextDirection = directionRotate;
            }
           
        }

        private void SetNextGoalRotation()
        {
            _goalRotateAngle = transform.eulerAngles + new Vector3(0, 90, 0) * (int) _directionRotate;
            if (_goalRotateAngle.y > 360)
                _goalRotateAngle -= new Vector3(0, 360, 0);
            if (_goalRotateAngle.y < 0)
                _goalRotateAngle += new Vector3(0, 360, 0);
                
            Debug.Log("Goal "+ _goalRotateAngle);
            Debug.Log(transform.eulerAngles);
        }

        private void FixedUpdate()
        {
            if (_inRotation)
            {
                transform.eulerAngles += new Vector3(0, _speedRotate, 0) * (int) _directionRotate;

                if (Vector3.Distance(transform.eulerAngles, _goalRotateAngle) <= _speedRotate )
                {
                    transform.eulerAngles = _goalRotateAngle;
                    _inRotation = false;
                  //  _usedLastRotation = true;
                    EndRotate();
                }
            }
        }
    }
}