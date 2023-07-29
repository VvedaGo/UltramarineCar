using System;
using UnityEngine;
using static Enums;

public class CarRotator : MonoBehaviour
{
    private InputSystem _inputSystem;
    private bool _inRotation;
    private DirectionRotate _directionRotate;

   
    private void Awake()
    {
       _inputSystem= FindObjectOfType<InputSystem>();
       _inputSystem.MouseDown += StartRotate;
       _inputSystem.MouseUp += EndRotate;
       _directionRotate = DirectionRotate.Left;
    }

    
    private void StartRotate()
    {
        Debug.Log("Start rotayte");
        _inRotation = true;
    }

    public void EndRotate()
    {
        Debug.Log("End rotate");
        _inRotation = false;
    }

    public void SetDirectionRotate(DirectionRotate directionRotate)
    {
        _directionRotate = directionRotate;
    }
    private void Update()
    {
        if (_inRotation)
        {
            transform.eulerAngles+=new Vector3(0,0.3f,0)*(int)_directionRotate;
        }
    }
}
