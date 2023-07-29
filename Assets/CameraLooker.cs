using UnityEngine;

public class CameraLooker : MonoBehaviour
{
    [SerializeField] private Vector3 _biasToLook;
   [SerializeField] private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void LateUpdate()
    {
        transform.position = _target.position + _biasToLook;
    }
}
