using System;
using UnityEngine;
using static Enums;

public class CarRotator : MonoBehaviour
{
    [SerializeField] private CarTriggerObserver _carTriggerObserver;
    private InputSystem _inputSystem;
    private bool _inRotation;
  [SerializeField]  private DirectionRotate _directionRotate;
    private bool _canRotate;
  //  private Vector3 _lastRotateAngle=new Vector3(0,90,0);
    private Vector3 _goalRotateAngle;
    private DirectionRotate _nextDirection;

   
    private void Awake()
    {
      _inputSystem= FindObjectOfType<InputSystem>();
       _inputSystem.MouseDown += StartRotate;
     //  _inputSystem.MouseUp += EndRotate;
       _carTriggerObserver.SetNewDirection += SetDirectionRotate;
       _directionRotate = DirectionRotate.Left;
    }

    private void OnDisable()
    {
        _inputSystem.MouseDown -= StartRotate;
      //  _inputSystem.MouseUp -= EndRotate;
        _carTriggerObserver.SetNewDirection -= SetDirectionRotate;
    }


    private void StartRotate()
    {
        Debug.Log("Start rotayte");
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
        _goalRotateAngle =  transform.eulerAngles + new Vector3(0, 90, 0) * (int)_directionRotate;
        if(_goalRotateAngle.y>=360)
            _goalRotateAngle-=new Vector3(0,360,0);
        if(_goalRotateAngle.y<0)
            _goalRotateAngle+=new Vector3(0,360,0);
    }

    public void SetDirectionRotate(DirectionRotate directionRotate)
    {
       
        if (!_inRotation)
        { _directionRotate = directionRotate;
            _canRotate = true;
            _goalRotateAngle =  transform.eulerAngles + new Vector3(0, 90, 0) * (int)_directionRotate;
            
        }
        else
        {
            _nextDirection = directionRotate;
        }
       
    }
    private void Update()
    {
        if (_inRotation)
        {
            transform.eulerAngles+=new Vector3(0,1.4f,0)*(int)_directionRotate;
            if(transform.eulerAngles.y>=360)
                transform.eulerAngles-=new Vector3(0,360,0);
            if(transform.eulerAngles.y<0)
                transform.eulerAngles+=new Vector3(0,360,0);
            if (Vector3.Distance(transform.eulerAngles, _goalRotateAngle) <= 3.8f)
            {
                transform.eulerAngles = _goalRotateAngle;
                _directionRotate = _nextDirection;
                EndRotate();
            }
        }
    }

    private void EndRotation()
    {
        
    }
}
