using System;
using UnityEngine;
using static Enums;

public class CarRotator : MonoBehaviour
{
    [SerializeField] private CarTriggerObserver _carTriggerObserver;
    private InputSystem _inputSystem;
    private bool _inRotation;
    private DirectionRotate _directionRotate;
    private bool _canRotate;

   
    private void Awake()
    {
       _inputSystem= FindObjectOfType<InputSystem>();
       _inputSystem.MouseDown += StartRotate;
       _inputSystem.MouseUp += EndRotate;
       _carTriggerObserver.SetNewDirection += SetDirectionRotate;
       _directionRotate = DirectionRotate.Left;
    }

    private void OnDisable()
    {
        _inputSystem.MouseDown -= StartRotate;
        _inputSystem.MouseUp -= EndRotate;
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
        Debug.Log("End rotate");
        _inRotation = false;
    }

    public void SetDirectionRotate(DirectionRotate directionRotate)
    {
        _directionRotate = directionRotate;
        _canRotate = true;
    }
    private void Update()
    {
        if (_inRotation)
        {
            transform.eulerAngles+=new Vector3(0,1.4f,0)*(int)_directionRotate;
        }
    }
}
