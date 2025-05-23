using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera Camera;
    
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 10f;
    [SerializeField] private float runSpeed = 22f;
    [SerializeField] private float rotationSpeed = 15f;
    private float currentSpeed;

    private Vector2 moveVector;
    private InputMaster input;

    private void OnEnable()
    {
        input.Enable();
    }


    private void OnDisable()
    {
        input.Disable();
    }

    private void Awake()
    {
        currentSpeed = walkSpeed;
        
        input = new InputMaster();

        input.Player.Movement.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += _ => moveVector = Vector2.zero;

        input.Player.Run.performed += _ => currentSpeed = runSpeed;
        input.Player.Run.canceled += _ => currentSpeed = walkSpeed;
    }

    void Update()
    {
        RotateToMouse();
        Move();
    }

    void Move()
    {
        Vector3 move = new Vector3(moveVector.x, 0, moveVector.y);
        //move = transform.right * move.x + transform.forward * move.z;
        
        controller.Move(move * (currentSpeed * Time.deltaTime));
    }

    void RotateToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.transform.position.y;
        Vector3 worldMousePos = Camera.ScreenToWorldPoint(mousePos);
        
        Vector3 direction = (worldMousePos - transform.position);
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public float GetNormalizedSpeed()
    {
        float velocity = controller.velocity.magnitude;
        return velocity / runSpeed;
    }

    public float CalculateDirection()
    {
        Vector3 movement = controller.velocity;
        
        if (movement == Vector3.zero) return 0f; // No movement

        // Project movement onto the character's plane
        Vector3 flattenedMovement = Vector3.ProjectOnPlane(movement, Vector3.up);
        Vector3 forward = transform.forward;
        
        // Calculate angle between forward direction and movement direction
        float angle = Vector3.SignedAngle(forward, flattenedMovement, Vector3.up);
        
        return angle;
    }
}