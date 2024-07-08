using UnityEngine;
using UnityEngine.AI;

public enum NPCState
{
    Idle,
    Chasing,
    Attacking,
    Dead
}

public class NPC : MonoBehaviour
{
    public Transform playertransform;
    public NavMeshAgent agent;
    public NPCState currentstate = NPCState.Idle;
    public float chaserange = 10f;
    public float attackRange = 5f;
    public Animator animator;
    public float outerRange = 20;
    public float animationSpeedMultiplier = 1.5f;
    public GameManager gm;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (currentstate == NPCState.Idle)
        {
            if (Vector3.Distance(playertransform.position, transform.position) < chaserange)
            {
                currentstate = NPCState.Chasing;
            }
            
        }
        else if (currentstate == NPCState.Chasing)
        {
            if (playertransform != null)
            {
                agent.SetDestination(playertransform.position);
                if (Vector3.Distance(transform.position, playertransform.position) < attackRange)
                {
                    currentstate = NPCState.Attacking;
                    agent.SetDestination(transform.position);
                }
            }

            // Set animator parameters based on the NavMeshAgent's velocity
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("Speed", speedPercent * animationSpeedMultiplier);

            // Play walking or running animation based on distance to player
            if (Vector3.Distance(transform.position, playertransform.position) < chaserange)
            {
                animator.SetBool("walking", true);
                animator.SetBool("running", false);
            }
            else
            {
                animator.SetBool("walking", false);
                animator.SetBool("running", true);
            }
        }
        else if (currentstate == NPCState.Attacking)
        {
            if (Vector3.Distance(transform.position, playertransform.position) > attackRange)
            {
                currentstate = NPCState.Chasing;
            }
            animator.SetBool("walking", false);
            animator.SetBool("idle", true);
            Debug.Log("Attacking");
            gm.FailLevel();
        }
        else if (currentstate == NPCState.Dead)
        {
            
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaserange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}