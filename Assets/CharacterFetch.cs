using UnityEngine;
using UnityEngine.AI;

public class CharacterFetch : MonoBehaviour
{
    public Transform ball;        // Assigne la balle dans l'inspecteur
    public Transform player;      // Assigne le joueur dans l'inspecteur
    public float grabDistance = 1.5f;  // Distance pour attraper la balle
    public float dropDistance = 1.5f;  // Distance pour lâcher la balle

    private NavMeshAgent agent;
    private Animator animator;
    private bool hasBall = false; // Indique si la balle est attrapée

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!hasBall)
        {
            if (Vector3.Distance(ball.position, player.position) > dropDistance)
            {
                // Aller vers la balle
                agent.SetDestination(ball.position);
                animator.SetBool("run", true);

                // Vérifier si proche de la balle
                if (Vector3.Distance(transform.position, ball.position) < grabDistance)
                {
                    GrabBall();
                }
            }
        }
        else
        {
            // Retourner vers le joueur
            agent.SetDestination(player.position + new Vector3(1, 1, 0));

            // Vérifier si proche du joueur pour lâcher la balle
            if (Vector3.Distance(transform.position, player.position) < dropDistance)
            {
                DropBall();
            }
        }
    }

    void GrabBall()
    {
        hasBall = true;
        ball.SetParent(transform); // Attache la balle au personnage
        ball.localPosition = new Vector3(0, 1, 1); // Position relative (ajuste selon ton modèle)
        animator.SetBool("run", true);
    }

    void DropBall()
    {
        hasBall = false;
        ball.SetParent(null); // Détache la balle
        ball.position = player.position + new Vector3(1, 1, 0); // Lâche la balle devant le joueur
        animator.SetBool("run", false);
    }
}
