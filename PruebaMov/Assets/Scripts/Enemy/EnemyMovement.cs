using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    float distance;
    Animator anim;                      // Reference to the animator component.
    bool walking;







    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void LateUpdate()
    {
        distance = Vector3.Distance(player.position, transform.position);

        // If the enemy and the player have health left...
        /*if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {*/
        // ... set the destination of the nav mesh agent to the player.
        if (distance < 5)
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
            walking = true;
        }
        else
        {
            nav.enabled = false;

            walking = false;
        }


        Animating(walking);

        /*}
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }*/
    }
     void Animating(bool walking)
    {
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }

}

