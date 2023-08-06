using UnityEngine;

namespace Game.Road
{
    public class Baricade : MonoBehaviour
    {
        public void DisableCollider()
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }
}
