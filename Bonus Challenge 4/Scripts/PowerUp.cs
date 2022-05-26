using UnityEngine;
public enum PowerUpType { None, Pushback, Rockets, Smash }

namespace bonusChallenge4
{
    public class PowerUp : MonoBehaviour
    {
        public PowerUpType powerUpType;
    }
}