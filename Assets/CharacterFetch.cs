using UnityEngine;
using UnityEngine.AI;

public class CharacterFetch : MonoBehaviour
{
    public Transform ball; // Assigne la balle dans l'inspecteur
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (ball != null)
        {
            agent.SetDestination(ball.position);
            animator.SetBool("run", true);

            // Si proche de la balle, arrêter
            if (Vector3.Distance(transform.position, ball.position) < 1.5f)
            {
                animator.SetBool("run", false);
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }
}