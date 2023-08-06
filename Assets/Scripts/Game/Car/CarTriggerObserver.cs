using System;
using Game.Road;
using UnityEngine;

namespace Game.Car
{
    public class CarTriggerObserver : MonoBehaviour
    {
        public Action Crash;
        public Action<Enums.DirectionRotate> SetNewDirection;
        public Action<int> OnScoreUp;
        public Action<int> OnCoinUp;
        public Action EnterOnCentre;
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out Baricade baricade))
            {
                baricade.DisableCollider();
                Crash?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
       
            if (other.transform.TryGetComponent(out ZoneDirectionSetter zoneDirectionSetter))
            {
                SetNewDirection?.Invoke(zoneDirectionSetter.GetRotation);
            }
            else if (other.transform.TryGetComponent(out ZoneScore zoneScore))
            {
                OnScoreUp?.Invoke(1);
            }
            else if (other.transform.TryGetComponent(out CentreTile centre))
            {
                EnterOnCentre?.Invoke();
            }
            else if (other.transform.TryGetComponent(out Coin coin))
            {
                coin.PickUp();
                OnCoinUp?.Invoke(1);
            }
        }
    }
}