using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PeopleSpawner : MonoBehaviour 
{
	public GameObject[] people;
	public Transform[] spawnPoints;

	private List<GameObject> instances;

	public static PeopleSpawner instance;

	private float lastVal = 0;

	void Awake()
	{
		instance = this;
		instances = new List<GameObject>();
	}

	public void CheckSpawn(float val)
	{
		float diff = val - lastVal;

		if (diff > 0)//population growth and we add a person
		{
			for (int k = 0; k < diff/3; k++)
			{
				SpawnPerson();
			}
		}
		else
		{
			for (int k = 0; k < diff/3; k++)
			{
				KillPerson();
			}
		}

		lastVal = val;
	}

	public void SpawnPerson()
	{
		Transform point = spawnPoints[Random.Range(0,spawnPoints.Length)];
		GameObject person = people[Random.Range(0,people.Length)];

		instances.Add(GameObject.Instantiate(person,point.position,point.rotation) as GameObject);
	}

	public void KillPerson()
	{
		GameObject person = instances[0];
		instances.RemoveAt(0);
		GameObject.Destroy(person);
	}

}


