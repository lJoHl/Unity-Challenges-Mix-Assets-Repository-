using UnityEngine;

namespace challenge5
{
    public class DestroyParticle : MonoBehaviour
    {
        // Destroy particle after 2 seconds
        private void Start()
        {
            Destroy(gameObject, 2);
        }
    }
}