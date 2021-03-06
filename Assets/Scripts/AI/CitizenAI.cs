﻿using UnityEngine;
using System.Collections;

public class CitizenAI : MonoBehaviour {
	
	NavMeshAgent agent;
	Animator anim;

	public float walkRadius = 100;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();

		StartCoroutine(AILoop());
	}

	IEnumerator AILoop()
	{
		Roam();
		while (true)
		{
			yield return new WaitForSeconds(0.2f);
		
			anim.SetFloat("agentSpeed",agent.velocity.magnitude);
			if (agent.remainingDistance < 2)
			{
				yield return StartCoroutine(whatNext());
			}
		}
	}


	private void Roam()
	{
		Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
		randomDirection += transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
		Vector3 finalPosition = hit.position;
		agent.SetDestination(finalPosition);
	}

	private IEnumerator whatNext()
	{
		float choice = Random.Range(0.0f, 1.0f);

		if (choice <= 0.5f)
		{
			Roam();
		}
		else
		{
			yield return new WaitForSeconds(Random.Range(2.0f, 7.0f));
		}

	}

}
