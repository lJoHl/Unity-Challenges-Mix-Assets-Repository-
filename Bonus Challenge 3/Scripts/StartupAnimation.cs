using System.Collections;
using UnityEngine;

namespace bonusChallenge3
{
    public class StartupAnimation : MonoBehaviour
    {
        private PlayerController playerControllerScript;

        [SerializeField] private Transform startingPoint;
        [SerializeField] private float lerpSpeed;


        private void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

            playerControllerScript.gameOver = true;

            StartCoroutine(PlayIntro());
        }

        IEnumerator PlayIntro()
        {
            Vector3 startPos = playerControllerScript.transform.position;
            Vector3 endPos = startingPoint.position;

            float journeyLength = Vector3.Distance(startPos, endPos);

            float startTime = Time.time;

            float distanceCovered = (Time.time - startTime) * lerpSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            playerControllerScript.GetComponent<Animator>().SetFloat("Speed_f", 0.5f);

            while (fractionOfJourney < 1)
            {
                distanceCovered = (Time.time - startTime) * lerpSpeed;
                fractionOfJourney = distanceCovered / journeyLength;

                playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

                yield return null;
            }

            playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
            playerControllerScript.gameOver = false;
            playerControllerScript.isOnGround = true;
        }
    }
}