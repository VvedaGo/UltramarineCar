using System;
using System.Collections.Generic;
using UnityEngine;

public class RoadDetector : MonoBehaviour
{
   public Action FromRoad;

   private List<Collider> _colliders;

   private void Awake()
   {
      _colliders=new List<Collider>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if(other.TryGetComponent(out ZoneDirectionSetter zoneDirectionSetter))
      {
        
         if (!_colliders.Contains(other))
         {
            _colliders.Add(other);
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if(other.TryGetComponent(out ZoneDirectionSetter zoneDirectionSetter))
      {
         if (_colliders.Contains(other))
         {
            _colliders.Remove(other);
         }

         CheckColliders();
      }
   }

   private void CheckColliders()
   {
      if (_colliders.Count == 0)
      {
         Debug.Log("crash");
         FromRoad?.Invoke();
      }
   }
}
