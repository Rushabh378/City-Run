using UnityEngine;

namespace CityRun
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody RB;
        private Vector3 movement;

        [SerializeField] private Animator animator;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 25f;
        [SerializeField] private GroundChecker groundChecker;

        private void Start()
        {
            RB = GetComponent<Rigidbody>();
            CameraAdjustment();
        }

        private void Update()
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, 1);

            transform.Translate(movement * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && groundChecker.isGrounded)
            {
                RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            if (movement != Vector3.zero)
            {
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Running", false);
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
