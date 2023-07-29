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
            Debug.Log("Invoke down");
            MouseDown?.Invoke();
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Invoe up");
            MouseUp?.Invoke();
        }
    }
}
