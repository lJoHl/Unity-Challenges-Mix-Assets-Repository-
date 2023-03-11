using UnityEngine;

namespace BonusChallenge5
{
    [RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

    public class ClickAndSwipe : MonoBehaviour
    {
        private GameManager gameManager;

        private Camera cam;
        private Vector3 mousePos;

        private TrailRenderer trail;
        private BoxCollider col;

        private bool swiping = false;


        private void Awake()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            cam = Camera.main;

            trail = GetComponent<TrailRenderer>();
            col = GetComponent<BoxCollider>();
        }


        private void Update()
        {
            if (gameManager.isGameActive)
            {
                if (Input.GetMouseButtonDown(0))
                    swiping = true;
                else if (Input.GetMouseButtonUp(0))
                    swiping = false;

                UpdateComponents();

                if (swiping)
                    UpdateMousePosition();
            }
        }


        private void UpdateComponents()
        {
            trail.enabled = swiping;
            col.enabled = swiping;
        }


        private void UpdateMousePosition()
        {
            mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            transform.position = mousePos;
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Target>())
                collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}