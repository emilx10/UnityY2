using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float rotationSpeed = 15f;

    [Header("Camera Settings")]
    public float cameraHeight = 10f; // How high above the player
    public float cameraAngle = 90f; // Straight down (90 degrees)

    private Animator animator;
    private CharacterController controller;
    private Vector3 moveDirection;
    private Transform cameraTransform;
    private float currentSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        InitializeCamera();
    }

    void InitializeCamera()
    {
        // Get or create main camera
        if (Camera.main == null)
        {
            GameObject cameraObj = new GameObject("TopDownCamera");
            cameraObj.AddComponent<Camera>();
            cameraObj.tag = "MainCamera";
        }

        cameraTransform = Camera.main.transform;
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        // Position directly above player's head
        Vector3 playerHeadPosition = transform.position + Vector3.up * 1.8f; // Approximate head height
        cameraTransform.position = playerHeadPosition + Vector3.up * cameraHeight;

        // Rotate to look straight down
        cameraTransform.rotation = Quaternion.Euler(cameraAngle, 0f, 0f);
    }

    void Update()
    {
        HandleMovement();
        UpdateCameraPosition(); // Camera updates every frame
    }

    void HandleMovement()
    {
        // Get input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Create movement vector (world space)
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Set speed based on shift key
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // Update animator
        float animationSpeed = moveDirection.magnitude > 0.1f ?
                            (Input.GetKey(KeyCode.LeftShift) ? 3f : 2.5f) :
                            0f;
        animator.SetFloat("Speed", animationSpeed);
    }

    void FixedUpdate()
    {
        // Apply movement
        if (moveDirection.magnitude > 0.1f)
        {
            controller.Move(moveDirection * currentSpeed * Time.fixedDeltaTime);

            // Face movement direction
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.fixedDeltaTime
                );
            }
        }

        // Apply gravity
        if (!controller.isGrounded)
        {
            controller.Move(Physics.gravity * Time.fixedDeltaTime);
        }
    }
}