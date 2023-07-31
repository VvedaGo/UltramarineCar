using System;
using UnityEngine;

public class CarTriggerObserver : MonoBehaviour
{
    public Action Crash;
    public Action<Enums.DirectionRotate> SetNewDirection;
    public Action<int> OnScoreUp;
    public Action EnterOnCentre;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnColision");
        if (other.transform.TryGetComponent(out Baricade baricade))
        {
            Crash?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On trigger");
        if (other.transform.TryGetComponent(out ZoneDirectionSetter zoneDirectionSetter))
        {
            SetNewDirection?.Invoke(zoneDirectionSetter.GetRotation);
        }
        if (other.transform.TryGetComponent(out ZoneScore zoneScore))
        {
            OnScoreUp?.Invoke(1);
        }

        if (other.transform.TryGetComponent(out CentreTile centre))
        {
            EnterOnCentre?.Invoke();
        }
    }
}