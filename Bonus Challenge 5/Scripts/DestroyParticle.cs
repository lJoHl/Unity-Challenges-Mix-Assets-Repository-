using UnityEngine;

namespace BonusChallenge5
{
    public class DestroyParticle : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 2);
        }
    }
}