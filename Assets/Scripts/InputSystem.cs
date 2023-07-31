using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Action MouseDown;
    public Action MouseUp;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            MouseDown?.Invoke();
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
           
            MouseUp?.Invoke();
        }
    }
}
