using System;
using UnityEngine;

namespace Infrastructure.Services
{
    public class InputSystem : MonoBehaviour
    {
        public Action MouseDown;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseDown?.Invoke();
            }
        }
    }
}
