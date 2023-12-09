using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityRun
{
    public class CapsuleController : MonoBehaviour
    {
        private Vector3 movement;
        private Rigidbody RB;

        public float speed = 5;
        public float shift = 5;
        public float jumpForce = 20;
        public GroundChecker groundChecker;

        private void Start()
        {
            CameraAdjustment();
            RB = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, 1);

            transform.Translate(movement * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && groundChecker.isGrounded)
            {
                RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("jumped pressed.");
            }
        }
        private void CameraAdjustment()
        {
            Camera.main.transform.parent = gameObject.transform;
            Camera.main.transform.position = gameObject.transform.position;
            Camera.main.transform.position += new Vector3(0f, 3.5f, -6f);
        }
    }
}
