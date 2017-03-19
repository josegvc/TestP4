using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovementNuevo : MonoBehaviour{


	Transform player;              
	NavMeshAgent nav;
	Animator anim;
	float distance;
	public float rango;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		anim = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
	}

	void LateUpdate()
	{
		distance = Vector3.Distance(player.position, transform.position);

		if (distance <= rango) {

			nav.enabled = true;
			nav.SetDestination(player.position);
			anim.SetBool ("Corriendo", true);
		}
	}
}

