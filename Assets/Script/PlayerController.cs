using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private float yVelocity = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float gravity = 1f;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    public void Update()
    {
        Move();
    }

    private void Move()
    {
       
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

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

        move.y = yVelocity;

        controller.Move(move * Time.deltaTime * speed);


        if(move != Vector3.zero)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
