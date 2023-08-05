using UnityEngine;

namespace Infrastructure.Services
{
    public class InputManager:IService
    {
        public bool GetMouseButton()
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}