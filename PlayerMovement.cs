using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float crouchSpeed = 1f;
    public float turnSmoothTime = 0.1f;
    public Transform cameraTransform;

    [Header("Physics Settings")]
    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    private float turnSmoothVelocity;
    private Animator anim;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // GRAVITY
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        bool isCrouching = Input.GetKey(KeyCode.LeftControl);

        if (inputDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            bool isRunning = Input.GetKey(KeyCode.LeftShift) && !isCrouching;
            float speed = isCrouching ? crouchSpeed : (isRunning ? runSpeed : walkSpeed);

            Vector3 finalMove = moveDir.normalized * speed + velocity;

            controller.Move(finalMove * Time.deltaTime);

            anim.SetBool("isWalking", !isRunning && !isCrouching);
            anim.SetBool("isRunning", isRunning);
        }
        else
        {
            controller.Move(new Vector3(0f, velocity.y, 0f) * Time.deltaTime);

            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

        anim.SetBool("isCrouch", isCrouching);

        // =========================================
        //               ATTACK TRIGGER
        // =========================================
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isAttack");
        }
    }

    // Dipanggil dari script lain saat player kena hit
    public void TakeDamage()
    {
        anim.SetTrigger("Hit");
    }
}
