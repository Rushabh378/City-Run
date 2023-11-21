using UnityEngine;

public enum Position
{
    Left,
    Center,
    Right
}

namespace CityRun
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        private Position current = Position.Center;
        private CharacterController controller;
        private float yVelocity = 0;
        private Vector3 targetPosition ;

        [SerializeField] private Animator animator;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float shift = 1f;
        [SerializeField] private float jumpForce = 15f;
        [SerializeField] private float gravity = 1f;

        public void Start()
        {
            controller = GetComponent<CharacterController>();
            targetPosition = transform.position;

            Camera.main.transform.parent = gameObject.transform;
        }
        public void Update()
        {
            Debug.Log("player position" + transform.position + "targer position : " + targetPosition);
            if (current != Position.Left && Input.GetKeyDown(KeyCode.A))
            {
                targetPosition -= Vector3.right * shift;
                current = ShiftLeft();
            }
            else if (current != Position.Right && Input.GetKeyDown(KeyCode.D))
            {
                targetPosition += Vector3.right * shift;
                current = ShiftRight();
            }

            if (controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    yVelocity = jumpForce;
                }
            }
            else
            {
                yVelocity -= gravity;
            }

            Move();
        }

        private void Move()
        {

            Vector3 move = Vector3.forward;

            if(Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                move.x = targetPosition.x;
            }

            move.y = yVelocity;

            controller.Move(move * Time.deltaTime * speed);


            if (move != Vector3.zero)
            {
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Running", false);
            }
        }

        private Position ShiftLeft()
        {
            if(current == Position.Center)
            {
                return Position.Left;
            }
            else
            {
                return Position.Center;
            }
        }
        private Position ShiftRight()
        {
            if(current == Position.Center)
            {
                return Position.Right;
            }
            else
            {
                return Position.Center;
            }
        }
    }
}