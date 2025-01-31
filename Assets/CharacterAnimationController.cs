using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private string speedParamName = "NormalizedSpeed";
    
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    
    private float _normalizedSpeed;

    private void Awake()
    {
        _navMeshAgent = GetComponentInParent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _normalizedSpeed = _navMeshAgent.velocity.normalized.magnitude;

        _animator.SetFloat(speedParamName, _normalizedSpeed);
    }
}
