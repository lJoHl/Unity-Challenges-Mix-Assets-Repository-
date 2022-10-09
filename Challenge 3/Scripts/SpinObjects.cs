﻿using UnityEngine;

namespace Challenge3
{
    public class SpinObjects : MonoBehaviour
    {
        public float spinSpeed;


        private void Update()
        {
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}