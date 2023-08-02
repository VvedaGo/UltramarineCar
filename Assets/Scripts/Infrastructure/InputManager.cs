using UnityEngine;

public class InputManager:IService
{
    public bool GetMouseButton()
    {
        return Input.GetMouseButtonDown(0);
    }
}