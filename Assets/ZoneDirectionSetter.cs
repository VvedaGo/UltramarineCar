using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDirectionSetter : MonoBehaviour
{
   [SerializeField] private Enums.DirectionRotate _directionToRotate;
   public Enums.DirectionRotate GetRotation => _directionToRotate;
}
