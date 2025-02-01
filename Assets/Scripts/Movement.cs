using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform EndGoal;
    public NavMeshSurface surface;
    public int AreaCost;
    public NavMeshAgent agent;
    public Text textPopup;
    public Animator animator;

    private float idleTimer = 0f;
    private float idleDuration = 2f;
    private bool canMove = false;

    void Start()
    {
        agent.SetAreaCost(NavMesh.GetAreaFromName("SkinnyObstacle"), AreaCost);
        textPopup.gameObject.SetActive(false);
        animator = GetComponent<Animator>();

        agent.isStopped = true;
        animator.SetFloat("Speed", 0);
    }

    private void Update()
    {
        if (!canMove)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleDuration)
            {
                canMove = true;
                agent.isStopped = false;
                agent.destination = EndGoal.position;
            }
        }

        float speed = agent.velocity.magnitude;

        if (canMove)
        {
            animator.SetFloat("Speed", speed);
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            textPopup.gameObject.SetActive(true);
        }
    }
}