using UnityEngine;

public class LocomotionAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TopDownMovement topDownMovement;

    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int dirHash = Animator.StringToHash("Direction");

    private void Update()
    {
        float normalizedSpeed = topDownMovement.GetNormalizedSpeed();
        float normalizedDirection = topDownMovement.CalculateDirection() / 180;

        animator.SetFloat(speedHash, normalizedSpeed);
        animator.SetFloat(dirHash, normalizedDirection);
    }
}
