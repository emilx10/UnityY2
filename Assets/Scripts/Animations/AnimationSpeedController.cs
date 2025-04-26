using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
public class AnimationSpeedController : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public float baseSpeed = 1f;
    public float MaxSpeed = 2f;

    void Start()
    {
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    
    void Update()
    {
        float agentSpeed = agent.velocity.magnitude;
        float speedRadius = agentSpeed / agent.speed;
        float newAnimationSpeed = Mathf.Lerp(baseSpeed, MaxSpeed, speedRadius);
        animator.speed = newAnimationSpeed;
        
    }
}
